using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolyclinicWebServices.Models
{
    public class Appointments
    {
        //Implement the logic here
        [Required]
        public int AppointmentNo { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public DateTime DateofAppointment { get; set; }

    }
}
