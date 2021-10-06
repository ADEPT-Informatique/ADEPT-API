using ADEPT_API.DATABASE.Models;
using ADEPT_API.DATABASE.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ADEPT_API.DATABASE.Context
{
    public class AdeptContext : DbContext
    {

        public AdeptContext(DbContextOptions<AdeptContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                     .AddJsonFile("config.json")
                                                                     .Build();

                optionsBuilder.UseSqlServer(configuration["AppSettings:connectionString"]);
            }
        }
    }
}
