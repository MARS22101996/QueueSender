using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using FortuneSender.BLL.Infrastructure.DI;
using FortuneSender.BLL.Interfaces;
using FortuneSender.BLL.Services;
using FortuneSender.Infrastrucrure.Automapper;

namespace FortuneSender.Infrastrucrure.DI
{
   public class DependencyResolver
   {
      public static void Setup()
      {
         var builder = new ContainerBuilder();

         builder.RegisterControllers(typeof(MvcApplication).Assembly);

         Configure(builder);

         DependencyResolverModuleBll.Configure(builder);

         var container = builder.Build();

         System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      }

      private static void Configure(ContainerBuilder builder)
      {
         builder.Register(c => AutoMapperConfiguration.Configure()).As<IMapper>()
         .InstancePerLifetimeScope().PropertiesAutowired().PreserveExistingDefaults();
         builder.RegisterType<FortuneService>().As<IFortuneService>();
      }
   }
}