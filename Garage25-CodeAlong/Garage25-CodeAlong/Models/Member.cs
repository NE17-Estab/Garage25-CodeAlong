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
                                                              //for one-one relationships we need to give like dis
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Column(TypeName="datetime2")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public String Address { get; set; }
        public string PhoneNum { get; set; }


        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}