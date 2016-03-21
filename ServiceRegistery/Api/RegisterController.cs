using ServiceRegistery.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ServiceRegistery.Api
{
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController 
    {
        private Dictionary<List<string>, string> _repo;

        public RegisterController()
        {
            _repo = new Dictionary<List<string>, string>();
        }
        
        [Route("save/{info}")]
        [HttpGet]
        public JsonResult<string> Save(string info)
        {
            //Todo: gelen verileri dictionarye at
            Console.WriteLine("Save :" + info);
            return Json(info);
        }

        [Route("getserviceinfo/{servicekey}")]
        [HttpGet]
        public JsonResult<string> GetServiceInfo(string serviceKey)
        {
            //Todo : Gelen servis adına göre uygun servis adreslerinden birini dönecek
            Console.WriteLine("GetServiceInfo :" + serviceKey);
            return Json(serviceKey);
        }
    }
}
