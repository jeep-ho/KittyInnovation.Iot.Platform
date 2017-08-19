using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KittyInnovation.Iot.Platform.Web.Startup))]
namespace KittyInnovation.Iot.Platform.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
