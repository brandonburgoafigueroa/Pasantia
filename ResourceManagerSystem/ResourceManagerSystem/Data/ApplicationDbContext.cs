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
        public DbSet<Accident> Accidents { set; get; }
        public DbSet<Administrative> Administratives { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Delivery> Deliveries { set; get; }
        public DbSet<Employee> Employes { set; get; }
        public DbSet<Enrolment> Enrolments { set; get; }
        public DbSet<Incident> Incidents { set; get; }
        public DbSet<Lot> Lots { set; get; }
        public DbSet<Operative> Positions { set; get; }
        public DbSet<OrganizingEntity> OrganizingEntities { set; get; }
        public DbSet<Person> People { set; get; }
        public DbSet<Provider> Providers { set; get; }
        public DbSet<REPP> Repps { set; get; }
        public DbSet<Region> Regions { set; get; }
        public DbSet<Sinister> Sinisters { set; get; }
        public DbSet<Stock> Stock { set; get; }

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
    }
}
