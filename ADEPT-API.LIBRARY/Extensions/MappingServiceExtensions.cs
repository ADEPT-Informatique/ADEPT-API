using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.LIBRARY.Services.Internals.MembreConfiance.Mappers;
using ADEPT_API.LIBRARY.Services.Internals.Users.Mappers;
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
            config.AddProfile(new ApplicationMappings());
            config.AddProfile(new UserMappings());
            config.AddProfile(new StudyProgrameMappings());
        });

        return mapperConfiguration.CreateMapper();
      });
    }

  }
}
