using System;
using System.Collections.Generic;

namespace PolyclinicDALCrossPlatform.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
    }
}
