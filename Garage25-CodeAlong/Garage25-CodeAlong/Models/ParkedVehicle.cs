using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [Column(TypeName="dateTime2")]
        public DateTime ParkingTime { get; set; }

       
        public int TypeId { get; set; }
   //   [ForeignKey("MemberId")]
        public int MemberId { get; set; }

        [ForeignKey("TypeId")]
        public virtual VehicleType VehicleType{get;set;}
     //   [Required]
        public virtual Member Member { get; set; }


       


    }
}