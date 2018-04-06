using System;
using System.Text;
using FortuneSender.DAL.Entities;
using FortuneSender.DAL.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace FortuneSender.DAL.Repositories
{
   public class RabbitMqRepository : IQueueRepository
   {
      private const string QueueName = "hello";
      private const string RabitMqHostName = "localhost";
      private readonly IConnection _connection;

      public RabbitMqRepository()
      {
         _connection = GetConnection();
      }

      public void Send(FortuneMessage message)
      {
         try
         {
            using (var channel = _connection.CreateModel())
            {
               channel.QueueDeclare(QueueName, false, false, false, null);

               var messageSerializeObject = JsonConvert.SerializeObject(message);
               var messageBytes = Encoding.UTF8.GetBytes(messageSerializeObject);

               var properties = channel.CreateBasicProperties();
               properties.Persistent = true;

               channel.BasicPublish(string.Empty, QueueName, properties, messageBytes);
            }
         }
         catch (Exception ex)
         {
            throw new Exception("Exception was throwed during sending the message", ex);
         }
      }

      private IConnection GetConnection()
      {
         var factory = new ConnectionFactory
         {
            Port = AmqpTcpEndpoint.UseDefaultPort,
            HostName = RabitMqHostName,
         };

         return factory.CreateConnection();
      }
   }
}
