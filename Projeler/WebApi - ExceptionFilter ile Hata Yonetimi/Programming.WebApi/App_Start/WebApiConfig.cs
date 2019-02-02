using Programming.WebApi.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Programming.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
       
            config.MapHttpAttributeRoutes();

            //BIR ATTRIBUYEI APPLICATION OLARAK UYGULAMAK 
            //TEK TEK HER CONTROLLERA YAZMAMAK ICIN
            config.Filters.Add(new HataYonetimi());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
