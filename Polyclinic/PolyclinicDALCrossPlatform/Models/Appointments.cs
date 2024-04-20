using System;
using System.Collections.Generic;

namespace PolyclinicDALCrossPlatform.Models
{
    public partial class Appointments
    {
        public int AppointmentNo { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime DateofAppointment { get; set; }


        //Navigational Property
        public Doctors Doctor { get; set; }   //foriegn key
        public Patients Patient { get; set; }
    }
}
