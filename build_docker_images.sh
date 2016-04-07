# build the template image to create actual build server image
docker build -t tge36-mono-onbuild -f ImageDockerfile .

# build the actual image to be used as build server
docker build -t tge36-build-app .

# run a temporary container and save its id
id=$(docker create tge36-build-app)

# copy build files from container to host
docker cp $id:/usr/src/app/build ./mono_build_output

# remove the temporary container
docker rm $id


#remove old images
docker rmi -f serviceregistery
docker rmi -f apigateway
docker rmi -f customerservice
docker rmi -f orderservice
docker rmi -f productservice
docker rmi -f authenticateservice
docker rmi -f movieservice
docker rmi -f node_service
docker rmi -f node_frontend

# now build each image one-by-one

cd  ./mono_build_output/ServiceRegistery 
docker build -t serviceregistery .

cd ../../
cd  ./mono_build_output/ApiGateway
docker build -t apigateway .

cd ../../
cd  ./mono_build_output/CustomerService
docker build -t customerservice .

cd ../../
cd  ./mono_build_output/OrderService
docker build -t orderservice .

cd ../../
cd  ./mono_build_output/ProductService
docker build -t productservice .

cd ../../
cd  ./mono_build_output/AuthenticateService
docker build -t authenticateservice .

cd ../../
cd  ./mono_build_output/MovieService
docker build -t movieservice .

#Node service build
cd ../../
cd  ./node_service
docker build -t node_service .

#Node frontend build
cd ../../
cd  ./node_frontend
docker build -t node_frontend .