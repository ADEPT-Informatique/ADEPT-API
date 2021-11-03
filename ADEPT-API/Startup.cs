using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Extensions;
using ADEPT_API.LIBRARY.Configurations;
using ADEPT_API.LIBRARY.Extensions;
using ADEPT_API.LIBRARY.Middleware;
using ADEPT_API.LIBRARY.Security.Extensions;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ADEPT_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdeptContext>(options => { options.UseSqlServer(AdeptConfig.Get("AppSettings:connectionString")); }, ServiceLifetime.Singleton);
            services.AddRepositoryServices();
            services.AddAdeptServices();
            services.AddMappingServices();
            services.AddAdeptAuthentificationServices();

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = ModelValidatorMiddleware.ValidateModelState;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ADEPT_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ADEPT_API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            string customToken = FirebaseAuth.DefaultInstance.CreateCustomTokenAsync("6TcvpIJOzeN4oUiGZO0RTiw8og93").GetAwaiter().GetResult();
            SignInWithCustomTokenAsync(customToken).GetAwaiter().GetResult();
        }

        private static async Task SignInWithCustomTokenAsync(string customToken)
        {
            string apiKey = AdeptConfig.Get("AppSettings:firebaseApiKey");
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new
                {
                    token = customToken,
                    returnSecureToken = true
                });
                var data = new StringContent(json, Encoding.UTF8, "application/json");



                var response = await client.PostAsync("https://identitytoolkit.googleapis.com/v1/accounts:signInWithCustomToken?key=" + apiKey, data);

                dynamic kekw = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                AdeptConfig.TestToken = kekw.idToken;

                //Arr�tez sur la ligne suivante pour obtenir l'idToken pour test
            }
        }

    }
}
