using ADEPT_API.LIBRARY.Services;
using ADEPT_API.LIBRARY.Services.Internals;
using ADEPT_API.LIBRARY.Services.Internals.MembreConfiance;
using ADEPT_API.Services.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.LIBRARY.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddAdeptServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStudyProgramService, StudyProgramService>();
            services.AddTransient<IQuestionService, QuestionService>();
        }
    }
}
