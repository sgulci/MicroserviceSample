using ServiceRegistery.Filter;
using System.Web.Http;

namespace ServiceRegistery
{
    public class Config
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            httpConfiguration.Filters.Add(new ErrorHandlingFilter());
        }
    }
}
