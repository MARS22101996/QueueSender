using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FortuneSender.BLL.Interfaces;
using FortuneSender.BLL.Services;

namespace FortuneSender.Infrastrucrure.DI
{
   public class DependencyResolverModule
   {
      public static void Setup()
      {
         var builder = new ContainerBuilder();

         builder.RegisterControllers(typeof(MvcApplication).Assembly);

         Configure(builder);

         var container = builder.Build();

         DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      }

      private static void Configure(ContainerBuilder builder)
      {
         builder.RegisterType<FortuneService>().As<IFortuneService>();
      }
   }
}