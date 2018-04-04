using FortuneSender.BLL.Models;

namespace FortuneSender.BLL.Interfaces
{
   public interface IFortuneService
   {
      FortuneMessage ConfigureAndSendFortuneMessage();
   }
}
