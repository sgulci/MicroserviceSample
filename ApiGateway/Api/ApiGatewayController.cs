
using System.Threading.Tasks;
using System.Web.Http;


namespace ApiGateway.Api
{
    [RoutePrefix("api/gateway")]
    public class ApiGatewayController : ApiController
    {

        [Route("getordersbycustomer/{customerid}")]
        [HttpGet]
        public string GetOrdersByCustomer(string customerid)
        {
            //Todo : önce service registery'den adresleri alacak sonra servisleri call edecek
            return customerid;
        }



        [Route("getproductsinorder/{customerid}")]
        [HttpGet]
        public string GetProductsInOrder(string orderid)
        {
            //Todo : Gelen servis adına göre uygun servis adreslerinden birini dönecek
            return orderid;
        }

        
    }
}
