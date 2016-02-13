using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WE.Api.Web.Startup))]
namespace WE.Api.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
