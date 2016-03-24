FROM mono:onbuild

#serviceregistery conf
EXPOSE 5000

CMD ["mono", "ServiceRegistery.exe"]

#apigateway conf
#EXPOSE 5001

#CMD ["mono", "ApiGateway.exe"]

#customer service conf
#EXPOSE 5002

#CMD ["mono", "CustomerService.exe"]

#order service conf
#EXPOSE 5003

#CMD ["mono", "OrderService.exe"]

#product service conf
#EXPOSE 5004

#CMD ["mono", "ProductService.exe"]