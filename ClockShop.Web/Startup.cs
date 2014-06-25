using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClockShop.Web.Startup))]
namespace ClockShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
