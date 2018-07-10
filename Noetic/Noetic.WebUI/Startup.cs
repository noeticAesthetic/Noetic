using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Noetic.WebUI.Startup))]
namespace Noetic.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
