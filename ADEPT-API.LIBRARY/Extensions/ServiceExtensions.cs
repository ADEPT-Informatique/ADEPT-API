﻿using ADEPT_API.LIBRARY.Services;
using ADEPT_API.LIBRARY.Services.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace ADEPT_API.LIBRARY.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddAdeptServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}