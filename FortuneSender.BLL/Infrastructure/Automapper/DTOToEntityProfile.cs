using AutoMapper;
using FortuneSender.BLL.Dto;
using FortuneSender.DAL.Entities;

namespace FortuneSender.BLL.Infrastructure.Automapper
{
   public class DtoToEntityProfile : Profile
   {
      public DtoToEntityProfile()
      {
         CreateMap<FortuneMessageDto, FortuneMessage>();
      }
   }
}