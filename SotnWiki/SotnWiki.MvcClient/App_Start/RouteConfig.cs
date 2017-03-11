using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SotnWiki.MvcClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Page",
                url: "{name}",
                defaults: new { controller = "Home", action = "Page" }
            );

            routes.MapRoute(
                name: "Edit",
                url: "Edit/{name}",
                defaults: new { controller = "Edit", action = "Edit" }
            );

            routes.MapRoute(
                name: "Edits",
                url: "{name}/Edits",
                defaults: new { controller = "Edit", action = "Edits" }
            );

            routes.MapRoute(
                name: "NewPage",
                url: "New_Page",
                defaults: new { controller = "Edit", action = "NewPage" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/{searchPhrase}",
                defaults: new { controller = "Search", action = "Search" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
