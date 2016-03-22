using CustomerService.Data;
using CustomerService.Model;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerService.Api
{
    public class CustomerController:ApiController
    {
        private MongoCustomerDb _repo;

        public CustomerController()
        {
            _repo = new MongoCustomerDb();
        }

        public JsonResult<string> Get()
        {
            return  Json("customer");
        }

        public async Task<Customer> Get(string id)
        {
            return await _repo.GetOrder(id);
        }

        public async Task<string> Post(Customer customer)
        {
            return await _repo.InsertOrder(customer);
        }
    }
}
