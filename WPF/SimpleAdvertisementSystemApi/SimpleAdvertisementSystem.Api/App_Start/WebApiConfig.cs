using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleAdvertisementSystem.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "CateogriesApi",
                routeTemplate: "api/categories/{categoryId}/{action}",
                defaults: new
                {
                    controller = "categories"
                }
            );

            config.Routes.MapHttpRoute(
                name: "TagsApi",
                routeTemplate: "api/tags/{tagId}/{action}",
                defaults: new
                {
                    controller = "tags"
                }
            );

            config.Routes.MapHttpRoute(
                name: "AdvertisementsApi",
                routeTemplate: "api/advertisements/{postId}/{action}",
                defaults: new
                {
                    controller = "advertisements"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UserLoginApi",
                routeTemplate: "api/auth/token",
                defaults: new { controller = "users", action = "token" });

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "users" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
