using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CollectionREPP> CollectionsREPP { set; get; }
        public DbSet<REPP> REPPS { set; get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ResourceManagerSystem.Models.Region> Region { get; set; }

        public DbSet<ResourceManagerSystem.Models.Administrative> Administrative { get; set; }

        public DbSet<ResourceManagerSystem.Models.Operative> Operative { get; set; }

        public DbSet<ResourceManagerSystem.Models.Employee> Employee { get; set; }

        public DbSet<ResourceManagerSystem.Models.OrganizingEntity> OrganizingEntity { get; set; }
    }
}
