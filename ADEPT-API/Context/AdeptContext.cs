using ADEPT_API.Models;
using ADEPT_API.Models.MembreConfiance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Context
{
    public class AdeptContext : DbContext
    {

        public AdeptContext(DbContextOptions<AdeptContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AdeptConfig.Get("AppSettings:connectionString"));
        }
    }
}
