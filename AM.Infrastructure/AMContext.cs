using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
   public  class AMContext : DbContext
    { public DbSet <Flight> Flights { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers{ get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
Initial Catalog=nahlamessaoudiDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
