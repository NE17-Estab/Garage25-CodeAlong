using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage25_CodeAlong.Models.ViewModel
{
    public class ParkVehicleViewModel
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int NrOfWheels { get; set; }
 
        public SelectList Members { get; set; }
        public SelectList Types { get; set; }

        public string MemberId { get; set; }
        public string TypesId { get; set; }

    }
}