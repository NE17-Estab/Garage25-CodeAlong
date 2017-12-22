using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage25_CodeAlong.DataAccess
{
    public class GarageContext: DbContext
    {
        public GarageContext() : base("Garage25-CA"){}
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }

    }
}