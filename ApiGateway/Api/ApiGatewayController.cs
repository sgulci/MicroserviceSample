
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiGateway.Api
{
    [RoutePrefix("api/gateway")]
    public class ApiGatewayController : ApiController
    {
#if !DEBUG
        string Service_Registery_Url = "http://192.168.99.100:5000/api/registery/getserviceinfo/";       

#else
        string Service_Registery_Url = "http://localhost:5000/api/registery/getserviceinfo/";
#endif


        [Route("getordersbycustomer/{customerid}")]
        [HttpGet]
        public JsonResult<string> GetOrdersByCustomer(string customerid)
        {
            Console.WriteLine("GetOrdersByCustomer customerid :" + customerid);

            Console.WriteLine("Calling registery service for customer ");

            string customerUrl = ServiceCall.RestService(Service_Registery_Url + "customer");

            if(customerUrl == "")
            {
                return Json("could not get customer url");
            }

            Console.WriteLine("Calling customer service ");

            string customers = ServiceCall.RestService("http://" + customerUrl.Replace("\"", "") + "/api/customer");

            Console.WriteLine("Calling registery service for order ");

            string orderUrl = ServiceCall.RestService(Service_Registery_Url + "order");

            Console.WriteLine("Calling order service ");

            if (orderUrl == "")
            {
                return Json("could not get order url");
            }

            string orders = ServiceCall.RestService("http://" + orderUrl.Replace("\"", "") + "/api/order");

            Console.WriteLine(" order service result " + orders);

            return Json(customerid + " : " + customers + orders);
        }



        [Route("getproductsinorder/{orderid}")]
        [HttpGet]
        public JsonResult<string> GetProductsInOrder(string orderid)
        {

            Console.WriteLine("GetProductsInOrder orderid :" + orderid);

            Console.WriteLine("Calling registery service for product ");

            string productUrl = ServiceCall.RestService(Service_Registery_Url + "product");

            if (productUrl == "")
            {
                return Json("could not get product url");
            }

            Console.WriteLine("Calling product service ");

            string products = ServiceCall.RestService("http://" + productUrl.Replace("\"", "") + "/api/product");

            Console.WriteLine("product service result " + products);

            Console.WriteLine("Calling registery service for order ");

            string orderUrl = ServiceCall.RestService(Service_Registery_Url + "order");

            if (orderUrl == "")
            {
                return Json("could not get order url");
            }

            Console.WriteLine("Calling order service ");

            string orders = ServiceCall.RestService("http://" + orderUrl.Replace("\"", "") + "/api/order");

            Console.WriteLine(" order service result " + orders);

            return Json(orderid + " : " + products + orders);
        }


        [Route("authenticate/{name}")]
        [HttpGet]
        public JsonResult<string> Authenticate(string name)
        {
            Console.WriteLine("Authenticate name :" + name);

            Console.WriteLine("Calling Authenticate service for " +  name);

            string authenticateUrl = ServiceCall.RestService(Service_Registery_Url + "authenticate");

            if (authenticateUrl == "")
            {
                return Json("could not get authenticate url");
            }
            Console.WriteLine("Calling authenticate service ");

            string result = ServiceCall.RestService("http://" + authenticateUrl.Replace("\"", "") + "/api/authenticate");


            return Json(result);
        }

    }
}
