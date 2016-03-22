using OrderService.Data;
using OrderService.Model;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace OrderService.Api
{
    public class OrderController : ApiController
    {
        private MongoOrderDb _repo;

        public OrderController()
        {
            _repo = new MongoOrderDb();
        }

        public JsonResult<string> Get()
        {
            return Json("order");
        }

        public async Task<Order> Get(string id)
        {
            return await _repo.GetOrder(id);
        }

        public async Task<string> Post(Order order)
        {
            return await _repo.InsertOrder(order);
        }
    }
}
