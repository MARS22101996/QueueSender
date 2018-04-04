using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FortuneSender.Infrastrucrure.DI;

namespace FortuneSender
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         DependencyResolverModule.Setup();
         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
   }
}
