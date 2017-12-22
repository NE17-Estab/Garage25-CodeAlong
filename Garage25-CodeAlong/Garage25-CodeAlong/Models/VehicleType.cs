using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage25_CodeAlong.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}