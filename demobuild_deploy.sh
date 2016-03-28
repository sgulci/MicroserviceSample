cd  ServiceRegistery 
 
docker build -t serviceregistery .
cd ..
cd  ApiGateway
docker build -t apigateway .
cd ..
cd  CustomerService
docker build -t customerservice .
cd ..
cd  OrderService
docker build -t orderservice .
cd ..
cd  ProductService 
docker build -t productservice .
cd ..
cd  Authenticate
docker build -t authenticateservice .
