using CompanyAPI.Core.Entities;
using CompanyAPI.Core.Repositories.EntityTypeConfigurations;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Core.Repositories
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("EfDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new CompanyConfigurations());
        }
    }
}
