using ApiGateway.Filter;
using System.Web.Http;

namespace ApiGateway
{
    public class Config
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            httpConfiguration.Filters.Add(new ErrorHandlingFilter());
        }
    }
}
