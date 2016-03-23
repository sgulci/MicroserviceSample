using ServiceRegistery.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ServiceRegistery.Api
{
    [RoutePrefix("api/registery")]
    public class RegisterController : ApiController
    {
       
        public RegisterController()
        {

        }

        [Route("save/{info}")]
        [HttpGet]
        public JsonResult<string> Save(string info)
        {
            //Todo: gelen verileri dictionarye at
            Console.WriteLine("Save :" + info);

            try
            {
                string url = info.Split(',')[0].ToString();
                string role = info.Split(',')[1].ToString();

                if (Repo.DB.ContainsKey(role))
                {
                    List<string> values = Repo.DB[role];
                    values.Add(url);
                    Repo.DB[role] = values;
                }
                else
                {
                    List<string> newValue = new List<string>();
                    newValue.Add(url);
                    Repo.DB.Add(role, newValue);
                }
                
            }
            catch (Exception ex )
            {
                info = " Registery service exception :" + ex.Message;
            }

            return Json(info);
        }

        [Route("getserviceinfo/{servicerole}")]
        [HttpGet]
        public JsonResult<string> GetServiceInfo(string serviceRole)
        {
            //Todo : Gelen servis adına göre uygun servis adreslerinden birini dönecek
            Console.WriteLine("GetServiceInfo serviceRole :" + serviceRole);
            string result = "";

            List<string> values = Repo.DB[serviceRole];
            int count = values.Count;

            if (count > 1)
            {
                Random rnd = new Random();
                int urlIndex = rnd.Next(0, count-1); 
                result = values[urlIndex];
            }
            else if(count == 1)
            {
                result = values[0];
            }
            else
            {
                result = "Cannot find microservice in that role :" + serviceRole;
            }

            Console.WriteLine("GetServiceInfo result :" + result);

            return Json(result);
        }
    }
}
