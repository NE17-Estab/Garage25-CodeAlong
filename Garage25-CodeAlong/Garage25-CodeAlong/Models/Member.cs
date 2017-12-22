using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage25_CodeAlong.Models
{
    public class Member
    {


         
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Column(TypeName="datetime")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNr { get; set; }

         public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}