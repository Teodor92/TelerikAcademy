using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam.Web.Startup))]
namespace Exam.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
