using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tools.Logger;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // autofac ioc container
            AutofacIocContainerConfig.RegisterContainer();

            var seqServerUrl = System.Configuration.ConfigurationManager.AppSettings["SeqServerUrl"];
            var seqAppKey = System.Configuration.ConfigurationManager.AppSettings["SeqApiKey"];
            LoggerSetup.ConfigureLogger(seqServerUrl, seqAppKey);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
