using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AuthenticateService.Api
{
    public class AuthenticateController : ApiController
    {

        public AuthenticateController()
        {
        }

        public JsonResult<string> Get()
        {
            Console.WriteLine("Called Authenticate service for Get");

            return  Json(true.ToString());
        }


        public JsonResult<string> Get(string name)
        {
            Console.WriteLine("Called Authenticate service for Get name :" + name);
            return Json(true.ToString()); 
        }

    }
}
