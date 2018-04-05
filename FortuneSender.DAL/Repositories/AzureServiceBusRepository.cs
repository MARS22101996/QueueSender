using System;
using System.Configuration;
using FortuneSender.DAL.Entities;
using FortuneSender.DAL.Interfaces;
using Microsoft.ServiceBus.Messaging;

namespace FortuneSender.DAL.Repositories
{
   public class AzureServiceBusRepository : IQueueRepository
   {
      private const string QueueName = "queue-maria";
      private readonly Lazy<string> _connectionServiceBus =
      new Lazy<string>(GetServiceBusConnection);
      private QueueClient _client;

      public AzureServiceBusRepository()
      {
         InitializeQueueClient();
      }

      public void Send(FortuneMessage fortuneMessage)
      {
         var message = new BrokeredMessage(fortuneMessage);

         _client.Send(message);
      }

      private static string GetServiceBusConnection()
      {
         try
         {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            return connectionString ?? string.Empty;
         }
         catch (ConfigurationErrorsException ex)
         {
            throw new Exception("Cannot read connection string from the config file", ex);
         }
      }

      private void InitializeQueueClient()
      {
         _client = QueueClient.CreateFromConnectionString(_connectionServiceBus.Value, QueueName);
      }
   }
}
