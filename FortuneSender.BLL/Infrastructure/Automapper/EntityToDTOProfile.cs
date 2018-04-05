using AutoMapper;
using FortuneSender.BLL.Dto;
using FortuneSender.DAL.Entities;

namespace FortuneSender.BLL.Infrastructure.Automapper
{
   public class EntityToDtoProfile : Profile
   {
      public EntityToDtoProfile()
      {
         CreateMap<FortuneMessage, FortuneMessageDto>();
      }
   }
}