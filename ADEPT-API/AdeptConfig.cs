using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API
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
