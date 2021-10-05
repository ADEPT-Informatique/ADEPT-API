using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.Extentions
{
  public static class MappingServiceExtensions
  {
    public static void AddMappingServices(this IServiceCollection services)
    {
      services.AddSingleton<IMapper>(serviceProvider =>
      {
        var mapperConfiguration = new MapperConfiguration(config => 
        { 

        });

        return mapperConfiguration.CreateMapper();
      });
    }

  }
}
