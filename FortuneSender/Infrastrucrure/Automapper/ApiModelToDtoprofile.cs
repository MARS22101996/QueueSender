using AutoMapper;
using FortuneSender.BLL.Dto;
using FortuneSender.ViewModels;

namespace FortuneSender.Infrastrucrure.Automapper
{
   public class ApiModelToDtoProfile : Profile
   {
      public ApiModelToDtoProfile()
      {
         CreateMap<FortuneMessageViewModel, FortuneMessageDto>();
      }
   }
}