using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Templete.Identity.Model;

namespace Templete.Identity.Context
{
   public class ApplicationContext : IdentityDbContext 
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
                base.OnModelCreating(builder);
                //builder.ApplyConfiguration(new EmployeeConfiguration());
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NoteCloud;Integrated Security=true");
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NoteCloud;Integrated Security=true");
            }
        }

        //public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
