using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirPortSystem.Startup))]
namespace AirPortSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
