using Garage25_CodeAlong.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage25_CodeAlong.DataAccess
{
    public class GarageContext : DbContext
    {
        public GarageContext () : base("Garage25-CA") { }
        public DbSet<Member> Members { get; set; }
        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}