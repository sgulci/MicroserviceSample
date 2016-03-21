using Owin;
using System.Web.Http;

namespace ApiGateway
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            Config.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}
