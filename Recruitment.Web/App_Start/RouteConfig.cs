using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Recruitment.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Client",
                url: "Client/{id}",
                defaults: new { controller = "Client", action = "Detail" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Profile",
                url: "Profile/{id}",
                defaults: new { controller = "Profile", action = "Detail" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Recruiter",
                url: "Recruiter/{id}",
                defaults: new { controller = "Recruiter", action = "Detail" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Role",
                url: "Role/{id}",
                defaults: new { controller = "Role", action = "Detail" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/{searchText}",
                defaults: new { controller = "Home", action = "Search" }
            );

            routes.MapRoute(
                name: "QuickSearch",
                url: "QuickSearch/{searchText}",
                defaults: new { controller = "Home", action = "QuickSearch" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}