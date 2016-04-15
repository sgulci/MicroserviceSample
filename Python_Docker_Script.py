
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
    cli = Client(base_url='tcp://127.0.0.1:2375')  # windows için docker 2375 olarak setlenmesi gerebilir

# TODO : Windows için sadece python client kullan?lmak zorunda kal?nabilir.Linux ile çal??t?ktan sonra tekrar gözden geçirilecek

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

# copy build files from container to host
os.system('docker cp %s:/usr/src/app/build ./mono_build_output' % build_container_id)

# remove the temporary container
os.system('docker rm %s'% build_container_id)



# TODO : run service docker images , when you run docker images docker cmd should take
# argument that contain service registery and microservices own url and port




# 1 dakika ara ile docker contianer instance'lar?n?n cpu'lar?n? kontrol eden ona
# göre yeni docker instance yaratan k?s?m


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
        #tmp = stat.stdout.read()
        c = '%'
        #print([pos for pos, char in enumerate(direct_output) if char == c])
        indexes = [pos for pos, char in enumerate(direct_output) if char == c]
        #print(float(direct_output[indexes[2]-5:indexes[2]].strip()))
        if float(direct_output[indexes[2] - 5:indexes[2]].strip()) > 0.0:
            # burada yeni bir docker instance olu?turulacak
            # container = cli.create_container(image='serviceregistery', command='/bin/sleep 30')
            print(0)
        #else:
        #    #burada sonraki containera geçilecek
        #    print(1)
    
    
        
        #for k, v in stats.items():
        #    if k == "cpu_stats":
        #        print("PUTVAL %s/%s/%s N:%s" %
        #        (container.get('Names')[0].lstrip('/'),'docker-cpu',types[0],v['cpu_usage']['total_usage']))

    time.sleep(60)  # Delay for 1 minute (60 seconds)

    