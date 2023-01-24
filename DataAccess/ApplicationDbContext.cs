using DataAccess.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<C2DUpdateEvent> DeviceUpdateEvents { get; set; }
        public DbSet<DHT11Reading> DHT11Readings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
