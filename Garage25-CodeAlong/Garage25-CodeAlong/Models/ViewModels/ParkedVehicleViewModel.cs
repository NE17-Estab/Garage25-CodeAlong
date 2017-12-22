using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage25_CodeAlong.Models.ViewModels
{
    public class ParkedVehicleViewModel
    {

        public string RegNum { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int NoOfWheels { get; set; }
        public DateTime ParkingTime { get; set; }

        public SelectList Members { get; set; }
        public SelectList Types { get; set; }
        public string MemberId { get; set; }
        public string TypesId { get; set; }
        
    }
}