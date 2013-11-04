using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using AirPortSystem.Data;



namespace AirPortSystem
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<AirPortDbContext, Configuration>());
        }
    }
}