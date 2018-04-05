using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FortuneSender.Infrastrucrure.Automapper;
using FortuneSender.Infrastrucrure.DI;
using DependencyResolver = FortuneSender.Infrastrucrure.DI.DependencyResolver;

namespace FortuneSender
{
   public class MvcApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         AutoMapperConfiguration.Configure();
         DependencyResolver.Setup();
         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
      }
   }
}
