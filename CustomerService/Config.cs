using CustomerService.Filters;
using System.Web.Http;

namespace CustomerService
{
    public class Config
    {
        static string Service_Registery_Url = "http://192.168.99.100:5000/api/registery/save/";
        static string Service_Registery_Url_Test = "http://localhost:5000/api/registery/save/";

        static string Service_Url = "192.168.99.100:5002";
        static string Service_Url_Test = "localhost:5002";

        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            httpConfiguration.Filters.Add(new ErrorHandlingFilter());

            ServiceCall.RestService(Service_Registery_Url + Service_Url  + ",customer");
        }
    }
}
