using ADEPT_API.Repositories.IRepository;
using ADEPT_API.Repositories.Repository;
using ADEPT_API.Services;
using ADEPT_API.Services.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.Extentions
{
    public static  class ServiceExtensions
    {

        public static void AddAdeptServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAuthRepository, AuthRepository>();
        }
    }
}
