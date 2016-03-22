using System.Web.Http;
using OrderService.Filters;

namespace OrderService
{
    public class Config
    {
        static string Service_Registery_Url = "http://192.168.99.100:5000/api/registery/save/";
        static string Service_Registery_Url_Test = "http://localhost:5000/api/registery/save/";

        static string Service_Url = "192.168.99.100:5003";
        static string Service_Url_Test = "localhost:5003";

        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            httpConfiguration.Filters.Add(new ErrorHandlingFilter());

            ServiceCall.RestService(Service_Registery_Url_Test + Service_Url_Test + ",order");
        }
    }
}
