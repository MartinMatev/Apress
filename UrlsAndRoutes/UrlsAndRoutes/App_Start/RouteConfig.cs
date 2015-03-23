using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Route myRoute = routes.MapRoute("AddContollerRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "UrlsAndRoutes.AdditionalControllers"});

            //// If nothing is found in the appropriate namespace, gets out a 404
            //myRoute.DataTokens["UseNamespaceFallback"] = false;

            routes.MapRoute("ChromeRoute", "{*catchall}",
                new { controller = "Home", action = "Index" },
                new { customConstraint = new UserAgentConstraint("Chrome") },
                new[] { "UrlsAndRoutes.AdditionalControllers" });

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^About$",
                    httpmethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                {
                    // A constaraint that requires ID made only of chars a-z with lenght of 6 !
                    new AlphaRouteConstraint(),
                    new MinLengthRouteConstraint(6)
                })
                },
                new[] { "URLsAndRoutes.Controllers" });


        }
    }
}
