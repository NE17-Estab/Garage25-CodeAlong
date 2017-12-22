using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage25_CodeAlong.DataAccessLayer
{
    public class GarageContext:DbContext
    {
       
        public GarageContext() : base("Garage25-CA") { }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }


    }
}