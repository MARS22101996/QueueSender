using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FortuneSender.BLL.Interfaces;
using FortuneSender.BLL.Models;
using Microsoft.ServiceBus.Messaging;

namespace FortuneSender.BLL.Services
{
   public class FortuneService : IFortuneService
   {
      private const string QueueName = "queue-maria";
      private readonly Lazy<string> _connectionServiceBus = 
         new Lazy<string>(GetServiceBusConnection);
      private QueueClient _client;
      private List<FortuneMessage> _listOFortuneMessages;

      public FortuneService()
      {
         InitializeMessages();

         InitializeQueueClient();
      }

      public FortuneMessage ConfigureAndSendFortuneMessage()
      {
         var fortuneMessage = GetFortuneMessage();

         var message = new BrokeredMessage(fortuneMessage);

         _client.Send(message);

         return fortuneMessage;
      }

      private FortuneMessage GetFortuneMessage()
      {
         var randomNumber = GenerateRandomNumber();

         var message = _listOFortuneMessages.FirstOrDefault(x => x.Id == randomNumber);

         return message;
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

      private static int GenerateRandomNumber()
      {
         var rnd = new Random();

         var randomNumber = rnd.Next(1, 4);
         return randomNumber;
      }

      private void InitializeMessages()
      {
         _listOFortuneMessages = new List<FortuneMessage>
         {
            new FortuneMessage {Id = 1, Topic = "Love", Body = "You will be happy in love"},
            new FortuneMessage {Id = 2, Topic = "Love", Body = "You will be divorsed"},
            new FortuneMessage {Id = 3, Topic = "Work", Body = "You will have well-paid work"},
            new FortuneMessage {Id = 4, Topic = "Work", Body = "You will have bad-paid work"}
         };
      }
   }
}
