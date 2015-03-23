using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            routes.MapMvcAttributeRoutes();
            //the URL pattern will match any two-segment URL where the first segment is Content and the second content has the .html extension
            routes.IgnoreRoute("Content/{filename}.html");

            routes.MapRoute("DiskFIle", "Content/StaticContent.html", new { controller = "Customer", action = "List" });

            routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(new LegacyRoute("~/articles/Windows_3.1_Overview", "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index"},
                new[] { "UrlsAndRoutes.Controllers" }
            );
            routes.MapRoute("MyOtherRoute", "App/{action}",
                new { controller = "Home"},
                new[] {"UrlsAndRoutes.Controllers"}
            );
        }
    }
}
