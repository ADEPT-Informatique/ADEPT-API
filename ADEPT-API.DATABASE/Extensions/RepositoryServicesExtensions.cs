using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATABASE.Repositories.Internals;
using ADEPT_API.DATABASE.Repositories.Internals.MembreConfiance;
using ADEPT_API.Repositories.Internals;
using ADEPT_API.Repositories.Internals.MembreConfiance;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.DATABASE.Extensions
{
    public static class RepositoryServicesExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IStudyProgramRepository, StudyProgramRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
        }
    }
}
