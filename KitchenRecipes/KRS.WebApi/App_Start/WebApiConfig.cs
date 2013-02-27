using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KRS.WebApi
{
    public static class WebApiConfig
    {
        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndId";
        public static string ControllerAction = "ApiControllerAction";

        public static void Register(HttpConfiguration config)
        {
            //api/sessions
            //api/speakers
            config.Routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "api/{controller}"
            );

            //api/session/4
            config.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" } //all digits
            );

            //custom actions
            //api/lookups/rooms
            config.Routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
