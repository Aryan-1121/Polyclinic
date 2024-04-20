using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyclinicWebServices.Models
{
    public class Patients
    {
        //Implement the logic here
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MinLength(10),MaxLength(10)]
        public string ContactNumber { get; set; }



    }
}
