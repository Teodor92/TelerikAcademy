using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleWebApp.Startup))]
namespace SimpleWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
