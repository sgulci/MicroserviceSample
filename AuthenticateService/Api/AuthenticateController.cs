using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace AuthenticateService.Api
{
    public class AuthenticateController : ApiController
    {

        public AuthenticateController()
        {
        }

        public HttpResponseMessage Get()
        {
            Console.WriteLine("Called Authenticate service for Get");

            return this.Request.CreateResponse(
                               HttpStatusCode.OK,
                               new { success = true });
        }


        public HttpResponseMessage Get(string name)
        {
            Console.WriteLine("Called Authenticate service for Get name :" + name);

            return this.Request.CreateResponse(
                             HttpStatusCode.OK,
                             new { success = true });
        }

    }
}
