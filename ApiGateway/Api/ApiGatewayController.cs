
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

        [Route("getordersbycustomer/{customerid}")]
        [HttpGet]
        public JsonResult<string> GetOrdersByCustomer(string customerid)
        {
            //Todo : önce service registery'den adresleri alacak sonra servisleri call edecek
            Console.WriteLine("GetOrdersByCustomer customerid :" + customerid);
            return Json(customerid);
        }



        [Route("getproductsinorder/{customerid}")]
        [HttpGet]
        public JsonResult<string>  GetProductsInOrder(string orderid)
        {
            //Todo :  önce service registery'den adresleri alacak sonra servisleri call edecek

            Console.WriteLine("GetProductsInOrder orderid :" + orderid);

           

            return Json( orderid);
        }

        private string CallRestService(string url)
        {

            //var url = "http://api.openweathermap.org/data/2.1/find/city?lat=51.50853&lon=-0.12574&cnt=10";

            Console.WriteLine("CallRestService url :" + url);

            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);


            return content;
        }
    }
}
