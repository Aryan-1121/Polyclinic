using System;
using System.Collections.Generic;

namespace PolyclinicDALCrossPlatform.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
        }

        public string DoctorId { get; set; }
        public string Specialization { get; set; }
        public string DoctorName { get; set; }
        public decimal Fees { get; set; }

        public ICollection<Appointments> Appointments { get; set; }  
    }
}
