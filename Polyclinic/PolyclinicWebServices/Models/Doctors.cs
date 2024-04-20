using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyclinicWebServices.Models
{
    public class Doctors
    {
        //Implement the logic here
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]

        public string DoctorName { get; set; }
        [Required]
        [Range(minimum:10000,maximum:double.MaxValue)]
        public decimal Fees { get; set; }

    }
}
