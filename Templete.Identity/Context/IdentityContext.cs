using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Templete.Identity.Model;

namespace Templete.Identity.Context
{
   public class IdentityContext: IdentityDbContext
    {
        public IdentityContext()
        {

        }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
                //base.OnModelCreating(builder);
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NoteCloud;Integrated Security=true");
                // Customize the ASP.NET Core Identity model and override the defaults if needed.
                // For example, you can rename the ASP.NET Core Identity table names and more.
                // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
