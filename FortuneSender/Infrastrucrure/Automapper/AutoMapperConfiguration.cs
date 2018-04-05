using AutoMapper;
using FortuneSender.BLL.Infrastructure.Automapper;

namespace FortuneSender.Infrastrucrure.Automapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToApiModelProfile>();
                cfg.AddProfile<ApiModelToDtoProfile>();

                ServiceAutoMapperConfiguration.Initialize(cfg);
            });

           var mapper = mapperConfiguration.CreateMapper();
           return mapper;
      }
    }
}