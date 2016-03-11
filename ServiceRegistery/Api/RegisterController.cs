using ServiceRegistery.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceRegistery.Api
{
    public class RegisterController : ApiController 
    {
        private Dictionary<List<Registery>, string> _repo;

        public RegisterController()
        {
            _repo = new Dictionary<List<Registery>, string>();
        }

        public  string Get(string id)
        {
            return  "ok";
        }

        public  string Post(string node)
        {
            return "ok";
        }
    }
}
