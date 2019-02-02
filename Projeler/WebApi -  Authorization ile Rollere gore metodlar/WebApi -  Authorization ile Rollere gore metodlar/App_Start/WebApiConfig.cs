using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new APIKeyLoginleme());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
