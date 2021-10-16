using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.LIBRARY.Services.Internals.MembreConfiance.Mappers;
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
            config.AddProfile(new QuestionMappings());
        });

        return mapperConfiguration.CreateMapper();
      });
    }

  }
}
