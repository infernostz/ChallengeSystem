using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CS.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetCurrentChallenges",
                url: "challenges",
                defaults: new { controller = "Home", action = "GetAll" }
            );

            routes.MapRoute(
                name: "GetCompletedChallenges",
                url: "challenges/completed",
                defaults: new { controller = "Home", action = "GetCompleted" }
            );

            routes.MapRoute(
                name: "GetNewChallangeForm",
                url: "challenges/post/new",
                defaults: new { controller = "Home", action = "NewChallenge" }
            );

            routes.MapRoute(
                name: "PostNewChallenge",
                url: "challenges/post",
                defaults: new { controller = "Home", action = "PostNewChallenge" }
            );

            routes.MapRoute(
                name: "GetChallengeDetails",
                url: "challenges/{id}",
                defaults: new { controller = "Home", action = "GetById" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetAll", id = UrlParameter.Optional }
            );
        }
    }
}