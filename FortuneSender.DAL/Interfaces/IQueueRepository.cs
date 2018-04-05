using FortuneSender.DAL.Entities;

namespace FortuneSender.DAL.Interfaces
{
   public interface IQueueRepository
   {
      void Send(FortuneMessage message);
   }
}
