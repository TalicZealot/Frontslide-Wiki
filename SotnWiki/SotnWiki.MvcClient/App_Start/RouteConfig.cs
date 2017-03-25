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
                name: "NewPage",
                url: "NewPage",
                defaults: new { controller = "Submissions", action = "NewPage" }
            );

            routes.MapRoute(
                name: "Edit",
                url: "Edit/{title}",
                defaults: new { controller = "Edit", action = "Edit" }
            );

            routes.MapRoute(
                name: "Publish",
                url: "Publish/{title}",
                defaults: new { controller = "Submissions", action = "Publish" }
            );

            routes.MapRoute(
                name: "PublishEdit",
                url: "{title}/PublishEdit/{id}",
                defaults: new { controller = "Edit", action = "PublishEdit" }
            );

            routes.MapRoute(
                name: "Search",
                url: "SearchResults",
                defaults: new { controller = "Search", action = "Search" }
            );

            routes.MapRoute(
                name: "Submissions",
                url: "Submissions",
                defaults: new { controller = "Submissions", action = "Submissions" }
            );

            routes.MapRoute(
                name: "Leaderboards",
                url: "Leaderboards",
                defaults: new { controller = "Leaderboards", action = "Leaderboards" }
            );

            routes.MapRoute(
                name: "Edits",
                url: "{title}/Edits",
                defaults: new { controller = "Edit", action = "Edits" }
            );

            routes.MapRoute(
                name: "Page",
                url: "{title}",
                defaults: new { controller = "Home", action = "Page" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
