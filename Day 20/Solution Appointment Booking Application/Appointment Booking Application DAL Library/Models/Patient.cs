using System;
using System.Collections.Generic;

namespace Appointment_Booking_Application_DAL_Library.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string? MedicalProblem { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
