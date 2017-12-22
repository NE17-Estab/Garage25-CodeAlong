using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage25_CodeAlong.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int NrOfWheels { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ParkingTime { get; set; }

        public int TypeId { get; set; }
        public int MemberId { get; set; }

        [ForeignKey("TypeId")]
        public virtual VehicleType VehicleType {get;set;}
        
        public virtual Member Member { get; set; }
    }
}