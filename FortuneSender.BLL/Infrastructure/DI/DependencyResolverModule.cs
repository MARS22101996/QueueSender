using Autofac;
using FortuneSender.DAL.Interfaces;
using FortuneSender.DAL.Repositories;

namespace FortuneSender.BLL.Infrastructure.DI
{
   public class DependencyResolverModuleBll
   {
      public static void Configure(ContainerBuilder builder)
      {
         builder.RegisterType<RabbitMqRepository>().As<IQueueRepository>();
      }
   }
}
