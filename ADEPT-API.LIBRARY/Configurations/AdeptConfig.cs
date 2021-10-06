using Microsoft.Extensions.Configuration;

namespace ADEPT_API.LIBRARY.Configurations
{
    public static class AdeptConfig
    {
        public static string TestToken { get; set; }

        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json", optional: true)
            .Build();
        public static string Get(string jsonPath)
        {
            return configuration[jsonPath];
        }

    }
}
