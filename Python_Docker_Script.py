
from docker import Client
import argparse
import os
import subprocess 
import time 
import sys


parser = argparse.ArgumentParser()

parser.add_argument('--env', action='store', dest='enviroment',
                    default='LINUX',
                    help='Store service enviroment, default is LINUX')

parser.add_argument('--ip', action='store', dest='service_ip',
                    default='217.78.97.197',
                    help='Store service ip, default is 217.78.97.197')

parser.add_argument('--watch-service', action='append', dest='watch_services',
                    default=['authenticateservice:0.01'],
                    help='Add service values to a list, default is ["authenticateservice:0.01"] usage : --watch-service authenticateservice:0.01 --watch-service customerservice:0.1',)

parser.add_argument('--new-docker-port', action='store', dest='new_port',type=int,
                    default=5020,
                    help='Store starting port number for new docker instances, default is 5020')


results = parser.parse_args()

watch_services = {}  

for service in results.watch_services:
    watch_services[service.split(':')[0]] = service.split(':')[1]


if results.enviroment == "LINUX":
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
os.system('docker rm %s' % build_container_id)

os.system('docker build -t serviceregistery ./mono_build_output/build/ServiceRegistery')

os.system('docker build -t apigateway ./mono_build_output/build/ApiGateway')

os.system('docker build -t customerservice ./mono_build_output/build/CustomerService')

os.system('docker build -t orderservice ./mono_build_output/build/OrderService')

os.system('docker build -t productservice ./mono_build_output/build/ProductService')

os.system('docker build -t authenticateservice ./mono_build_output/build/AuthenticateService')

os.system('docker build -t movieservice ./mono_build_output/build/MovieService')

os.system('docker build -t node_service ./node_service')

os.system('docker build -t node_frontend ./node_frontend')


# TODO : run service docker images , when you run docker images docker cmd
# should take
# argument that contain service registery and microservices own url and port
Service_Registery_Url = "http://" + results.service_ip + ":5000/api/registery"
#Service_Registery_Url_Info = "http://217.78.97.197:5000/api/registery"
Service_IP = results.service_ip
os.system('docker run -pd 5000:5000 serviceregistery "mono" "/app/ServiceRegistery.exe" "http://*:5000"')
os.system('docker run -pd 5001:5001 apigateway "mono" "/app/ApiGateway.exe" "http://*:5001" %s' % Service_Registery_Url)
os.system('docker run -pd 5002:5002 customerservice "mono" "/app/CustomerService.exe" "http://*:5002"  %s %s' % (Service_Registery_Url,Service_IP + ":5002"))
os.system('docker run -pd 5003:5003 orderservice "mono" "/app/OrderService.exe" "http://*:5003"  %s %s' % (Service_Registery_Url,Service_IP + ":5003"))
os.system('docker run -pd 5004:5004 productservice "mono" "/app/ProductService.exe" "http://*:5004" %s %s' % (Service_Registery_Url,Service_IP + ":5004"))
os.system('docker run -pd 5005:5005 authenticateservice "mono" "/app/AuthenticateService.exe" "http://*:5005" %s %s' % (Service_Registery_Url,Service_IP + ":5005"))
os.system('docker run -pd 5006:5006 movieservice "mono" "/app/MovieService.exe" "http://*:5006" %s %s' % (Service_Registery_Url,Service_IP + ":5006"))
os.system('docker run -pd 3000:3000 node_service')
os.system('docker run -pd 8080:8080 node_frontend')

microservices = {}
microservices['customerservice'] = "/app/CustomerService.exe"
microservices['orderservice'] = "/app/OrderService.exe"
microservices['productservice'] = "/app/ProductService.exe"
microservices['authenticateservice'] = "/app/AuthenticateService.exe"
microservices['movieservice'] = "/app/MovieService.exe"

# 1 dakika ara ile docker contianer instance'lar?n?n cpu'lar?n? kontrol eden
# ona gore yeni docker instance yaratan kisim
new_port = results.new_port

containers = cli.containers()

while True:
    
    for container in containers:
        if container.get("Image") in watch_services:
            
            direct_output = subprocess.check_output('docker stats --no-stream %s' % container.get("Id"), shell=True)
            c = '%'        
            indexes = [pos for pos, char in enumerate(direct_output) if char == c]

            if float(direct_output[indexes[2] - 5:indexes[2]].strip()) > float(watch_services[container.get("Image")]):
                # container = cli.create_container(image='serviceregistery',command='/bin/sleep 30')
                 os.system('docker run -pd %d:%d %s mono %s http://*:%d %s %s' % (new_port,new_port,container.get("Image"),microservices[container.get("Image")],new_port,Service_Registery_Url,Service_IP + ":" + str(new_port)))
                 new_port = new_port + 1
 

    time.sleep(120)  # Delay for 1 minute (60 seconds)

    