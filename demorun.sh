
docker pull mongo
docker kill demodb

docker run --name demodb -p 27017:27017 -d mongo

docker run -pd 5000:5000 serviceregistery
docker run -pd 5001:5001 apigateway
docker run -pd 5002:5002 customerservice
docker run -pd 5003:5003 orderservice
docker run -pd 5004:5004 productservice
docker run -pd 5005:5005 authenticateservice
docker run -pd 5006:5006 movieservice


docker run -pd 3000:3000 node_service
docker run -pd 8080:8080 node_frontend