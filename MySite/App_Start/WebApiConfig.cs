using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace MySite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200", "*", "GET,POST,DELETE,PUT");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "CustomGet",
            //    routeTemplate: "api/{controller}/{action}/{title}/{id}",
            //    defaults: new { title= UrlParameter.Optional, id = RouteParameter.Optional }
            //);


            //config.Routes.MapHttpRoute(
            //    name: "AppFieldList",
            //    routeTemplate: "api/AppFieldList/{id}",
            //    defaults: new {  action = "AppFieldList", id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "AppFieldList",
                routeTemplate: "api/{controller}/SubList/{id}",
                defaults: new { action = "SubList", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
