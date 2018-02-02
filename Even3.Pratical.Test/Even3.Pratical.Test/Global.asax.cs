using LightInject;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Even3.Pratical.Test
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var configuration = GlobalConfiguration.Configuration;

            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ViewEngines.Engines.OfType<RazorViewEngine>().First().ViewLocationFormats = new string[] {
                "~/Presentation/Views/{1}/{0}.cshtml",
                "~/Presentation/Views/{0}.cshtml"
            };

            RouteTable.Routes.MapRoute(
                name: "DefaultMvc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );

            configuration.Routes.MapHttpRoute(
                name: "DefaultRestApi",
                routeTemplate: "rest/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var serviceContainer = new ServiceContainer();
            serviceContainer.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            serviceContainer.RegisterApiControllers();
            serviceContainer.EnableWebApi(configuration);
        }
    }
}