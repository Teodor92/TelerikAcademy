using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JusTeeth.App.Startup))]
namespace JusTeeth.App
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
