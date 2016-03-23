
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
        string Service_Registery_Url = "http://192.168.99.100:5000/api/registery/getserviceinfo/";
        string Service_Registery_Url_Test = "http://localhost:5000/api/registery/getserviceinfo/";

        [Route("getordersbycustomer/{customerid}")]
        [HttpGet]
        public JsonResult<string> GetOrdersByCustomer(string customerid)
        {
            //Todo : önce service registery'den adresleri alacak sonra servisleri call edecek
            Console.WriteLine("GetOrdersByCustomer customerid :" + customerid);

            Console.WriteLine("Calling registery service for customer ");

            string customerUrl = ServiceCall.RestService(Service_Registery_Url + "customer");

            Console.WriteLine("Calling customer service " );

            string customers = ServiceCall.RestService("http://"+ customerUrl.Replace("\"","") + "/api/customer");

            Console.WriteLine("Calling registery service for order ");

            string orderUrl = ServiceCall.RestService(Service_Registery_Url + "order");

            Console.WriteLine("Calling order service ");

            string orders = ServiceCall.RestService("http://" + orderUrl.Replace("\"", "") + "/api/order");

            Console.WriteLine(" order service result " + orders);

            return Json(customerid +" : " + customers + orders );
        }



        [Route("getproductsinorder/{orderid}")]
        [HttpGet]
        public JsonResult<string>  GetProductsInOrder(string orderid)
        {
            //Todo :  önce service registery'den adresleri alacak sonra servisleri call edecek

            Console.WriteLine("GetProductsInOrder orderid :" + orderid);

            Console.WriteLine("Calling registery service for product ");

            string productUrl = ServiceCall.RestService(Service_Registery_Url + "product");

            Console.WriteLine("Calling product service ");

            string products = ServiceCall.RestService("http://" + productUrl.Replace("\"", "") + "/api/product");

            Console.WriteLine("product service result " + products);

            Console.WriteLine("Calling registery service for order ");

            string orderUrl = ServiceCall.RestService(Service_Registery_Url + "order");

            Console.WriteLine("Calling order service ");

            string orders = ServiceCall.RestService("http://" + orderUrl.Replace("\"", "") + "/api/order");

            Console.WriteLine(" order service result " + orders);

            return Json(orderid +" : "+ products + orders);
        }
        
    }
}
