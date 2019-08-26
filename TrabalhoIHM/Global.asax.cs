using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrabalhoIHM.App_Start;
using TrabalhoIHM.Auto_Mapper;

namespace TrabalhoIHM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorConfig.RegisterComponents();
            AutoMapper_config.RegisterMappings();
        }
    }
}
