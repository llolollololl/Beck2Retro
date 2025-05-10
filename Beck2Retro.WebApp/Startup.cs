using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beck2Retro.WebApp.Startup))]
namespace Beck2Retro.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
