using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.LIBRARY.Dto.Users;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.LIBRARY.Extensions
{
  public static class MappingServiceExtensions
  {
    public static void AddMappingServices(this IServiceCollection services)
    {
      services.AddSingleton<IMapper>(serviceProvider =>
      {
        var mapperConfiguration = new MapperConfiguration(config => 
        {
            config.CreateMap<StudyProgram, StudyProgramDto>();
        });

        return mapperConfiguration.CreateMapper();
      });
    }

  }
}
