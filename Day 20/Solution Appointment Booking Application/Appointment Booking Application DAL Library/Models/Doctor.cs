using System;
using System.Collections.Generic;

namespace Appointment_Booking_Application_DAL_Library.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Doctor(int doctorId, string? name, string? contactNumber, string? specialization)
        {
            DoctorId = doctorId;
            Name = name;
            ContactNumber = contactNumber;
            Specialization = specialization;
        }

        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
