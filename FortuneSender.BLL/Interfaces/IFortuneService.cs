using FortuneSender.BLL.Dto;

namespace FortuneSender.BLL.Interfaces
{
   public interface IFortuneService
   {
      FortuneMessageDto ConfigureAndSendFortuneMessage();
   }
}
