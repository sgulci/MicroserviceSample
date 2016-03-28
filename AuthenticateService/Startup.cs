using Owin;
using System.Web.Http;

namespace AuthenticateService
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
