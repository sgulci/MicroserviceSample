using ProductService.Data;
using ProductService.Model;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProductService.Api
{
    public class ProductController:ApiController
    {
        private MongoProductDb _repo;

        public ProductController()
        {
            _repo = new MongoProductDb();
        }

        public JsonResult<string> Get()
        {
            return Json("product");
        }

        public async Task<Product> Get(string id)
        {
            return await _repo.GetOrder(id);
        }

        public async Task<string> Post(Product product)
        {
            return await _repo.InsertOrder(product);
        }
    }
}
