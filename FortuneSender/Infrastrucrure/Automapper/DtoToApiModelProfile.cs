using AutoMapper;
using FortuneSender.BLL.Dto;
using FortuneSender.ViewModels;

namespace FortuneSender.Infrastrucrure.Automapper
{
   public class DtoToApiModelProfile : Profile
   {
      public DtoToApiModelProfile()
      {
         CreateMap<FortuneMessageDto, FortuneMessageViewModel>();
      }
   }
}