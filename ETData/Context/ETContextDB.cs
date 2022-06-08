using ETData.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETData.Context
{
    public class ETContextDB : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<TravelAgency> TravelAgencies { get; set; }
    }
}
