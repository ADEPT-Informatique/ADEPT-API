using ADEPT_API.LIBRARY.Firebase.Authentification.Adapters.Internals;
using ADEPT_API.LIBRARY.Firebase.Authentification.Managers;
using ADEPT_API.LIBRARY.Firebase.Authentification.Managers.Internals;
using ADEPT_API.LIBRARY.Security.Handlers;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ADEPT_API.LIBRARY.Security.Extensions
{
    public static class AdeptAuthentificationServices
    {
        public static void AddAdeptAuthentificationServices(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("firebase-auth.json"),
                ProjectId = "adept-api"
            });
            services.AddTransient<IFirebaseAuthAdapter>(provider =>
            {
                var googleCredential = GoogleCredential.FromFile("firebase-auth.json");
                return new FirebaseAuthAdapter(googleCredential, "adept-api");
            });
            services.AddTransient<IFirebaseAuthManager, FirebaseAuthManager>();
            services.AddTransient<IAuthorizationHandler, AdeptRoleAuthorizationHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.Authority = "https://securetoken.google.com/adept-api";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/adept-api",
                    ValidateAudience = true,
                    ValidAudience = "adept-api",
                    ValidateLifetime = true
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Roles", configurePolicy =>
                {
                    configurePolicy.AddAuthenticationSchemes("Bearer")
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                    configurePolicy.Requirements.Add(new RoleAuthorizationRequirement());
                });
            });
        }
    }
}
