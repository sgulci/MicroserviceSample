using CustomerService.Data;
using CustomerService.Model;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerService.Api
{
    class CustomerController:ApiController
    {
        private MongoCustomerDb _repo;

        public CustomerController()
        {
            _repo = new MongoCustomerDb();
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
