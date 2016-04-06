cd  ./ServiceRegistery/bin/Release 
docker build -t serviceregistery .

cd ../../../
cd  ./ApiGateway/bin/Release 
docker build -t apigateway .

cd ../../../
cd  ./CustomerService/bin/Release 
docker build -t customerservice .

cd ../../../
cd  ./OrderService/bin/Release 
docker build -t orderservice .

cd ../../../
cd  ./ProductService/bin/Release 
docker build -t productservice .

cd ../../../
cd  ./AuthenticateService/bin/Release 
docker build -t authenticateservice .
