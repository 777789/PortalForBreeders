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

        public DbSet<Bydlo> BydloProducts { get; set; }
        public DbSet<Trzoda> TrzodaProducts { get; set; }
        public DbSet<Ges> GesProducts { get; set; } 
    }
}