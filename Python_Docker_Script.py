
from docker import Client
import os
import subprocess 
import time 
import sys


# TODO : Parametre olarak linux yada windows olarak ortam bilgisi al?nacak
total = len(sys.argv)
cmdargs = str(sys.argv)

# If there is no argument we assume it is LINUX deployment
if total > 1:
    env = str(sys.argv[1])
else:
    env = "LINUX" 


if env == "LINUX":
    cli = Client(base_url='unix:///var/run/docker.sock')
else:
    # windows icin docker 2375 olarak setlenmesi gerebilir
    cli = Client(base_url='tcp://127.0.0.1:2375')  

# TODO : Windows icin sadece python client kullanilmak zorunda kalinabilir

#kill running docker instance
os.system('docker rm -f $(docker ps -aq)')

#remove old images
#docker rmi -f $(docker images -aq)
os.system('docker rmi -f serviceregistery')
os.system('docker rmi -f apigateway')
os.system('docker rmi -f customerservice')
os.system('docker rmi -f orderservice')
os.system('docker rmi -f productservice')
os.system('docker rmi -f authenticateservice')
os.system('docker rmi -f movieservice')
os.system('docker rmi -f node_service')
os.system('docker rmi -f node_frontend')

# build the template image to create actual build server image
os.system('docker build -t tge36-mono-onbuild -f ImageDockerfile .')

# build the actual image to be used as build server
os.system('docker build -t tge36-build-app .')

# run a temporary container and save its id
build_container_id = subprocess.check_output('docker create tge36-build-app' , shell=True)   

#print("build_container_id :" + build_container_id[0:12])

#os.system('docker ps')

# copy build files from container to host
os.system('docker cp %s:/usr/src/app/build ./mono_build_output' % build_container_id[0:12])

# remove the temporary container
os.system('docker rm %s'% build_container_id)

os.system('docker build -t serviceregistery ./mono_build_output/build/ServiceRegistery')

os.system('docker build -t apigateway ./mono_build_output/build/ApiGateway')

os.system('docker build -t customerservice ./mono_build_output/build/CustomerService')

os.system('docker build -t orderservice ./mono_build_output/build/OrderService')

os.system('docker build -t productservice ./mono_build_output/build/ProductService')

os.system('docker build -t authenticateservice ./mono_build_output/build/AuthenticateService')

os.system('docker build -t movieservice ./mono_build_output/build/MovieService')
#Node service build
os.system('docker build -t node_service ./node_service')
#Node frontend build
os.system('docker build -t node_frontend ./node_frontend')


# TODO : run service docker images , when you run docker images docker cmd should take
# argument that contain service registery and microservices own url and port
Service_Registery_Url = "http://217.78.97.197:5000/api/registery"
#Service_Registery_Url_Info = "http://217.78.97.197:5000/api/registery"
Service_IP = "217.78.97.197"
os.system('docker run -pd 5000:5000 serviceregistery "mono" "/app/ServiceRegistery.exe" "http://*:5000"')
os.system('docker run -pd 5001:5001 apigateway "mono" "/app/ApiGateway.exe" "http://*:5001" %s' % Service_Registery_Url)
os.system('docker run -pd 5002:5002 customerservice "mono" "/app/CustomerService.exe" "http://*:5002"  %s %s' % (Service_Registery_Url,Service_IP +":5002"))
os.system('docker run -pd 5003:5003 orderservice "mono" "/app/OrderService.exe" "http://*:5003"  %s %s' % (Service_Registery_Url,Service_IP +":5003"))
os.system('docker run -pd 5004:5004 productservice "mono" "/app/ProductService.exe" "http://*:5004" %s %s' % (Service_Registery_Url,Service_IP +":5004"))
os.system('docker run -pd 5005:5005 authenticateservice "mono" "/app/AuthenticateService.exe" "http://*:5005" %s %s' % (Service_Registery_Url,Service_IP +":5005"))
os.system('docker run -pd 5006:5006 movieservice "mono" "/app/MovieService.exe" "http://*:5006" %s %s' % (Service_Registery_Url,Service_IP +":5006"))
os.system('docker run -pd 3000:3000 node_service')
os.system('docker run -pd 8080:8080 node_frontend')


# 1 dakika ara ile docker contianer instance'lar?n?n cpu'lar?n? kontrol eden ona
# gore yeni docker instance yaratan kisim
new_port = 5020

containers = cli.containers()

while True:
    
    for container in containers:
        #stats = json.loads(cli.stats(container["Id"]))
        #stats = cli.stats(container = container.get("Id"),stream = False)
        #stat = os.system('docker stats --no-stream %s' % container.get("Id"))
        #print(stat)
    
        #value = stat.read()
        #print(value)
        #stat = Popen('docker stats --no-stream %s' % container.get("Id"),
        #stdout=PIPE)
        direct_output = subprocess.check_output('docker stats --no-stream %s' % container.get("Id"), shell=True)
        c = '%'
        #print([pos for pos, char in enumerate(direct_output) if char == c])
        indexes = [pos for pos, char in enumerate(direct_output) if char == c]
        #print(float(direct_output[indexes[2]-5:indexes[2]].strip()))
        if float(direct_output[indexes[2] - 5:indexes[2]].strip()) > 0.01:
            # burada yeni bir docker instance olusturulacak
            # container = cli.create_container(image='serviceregistery', command='/bin/sleep 30')
            if container.get("Image") == "authenticateservice":
                #print('docker run -pd %d:%d authenticateservice mono /app/AuthenticateService.exe http://*:%d %s %s' % (new_port,new_port,new_port,Service_Registery_Url,Service_IP +":"+ str(new_port)))
                os.system('docker run -pd %d:%d authenticateservice mono /app/AuthenticateService.exe http://*:%d %s %s' % (new_port,new_port,new_port,Service_Registery_Url,Service_IP +":"+ str(new_port)))
                new_port = new_port + 1
        #for k, v in stats.items():
        #    if k == "cpu_stats":
        #        print("PUTVAL %s/%s/%s N:%s" %
        #        (container.get('Names')[0].lstrip('/'),'docker-cpu',types[0],v['cpu_usage']['total_usage']))

    time.sleep(120)  # Delay for 1 minute (60 seconds)

    