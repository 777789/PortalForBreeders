using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EndToEnd.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BydloModels> BydloProducts { get; set; }
        public DbSet<TrzodaModels> TrzodaProducts { get; set; }
        public DbSet<KuraModels> KuraProducts { get; set; } 
        public DbSet<KaczkaModels> KaczkaProducts { get; set; }
        public DbSet<GesModels> GesProducts { get; set; }
        public DbSet<IndykModels> IndykProducts { get; set; }

    }
}