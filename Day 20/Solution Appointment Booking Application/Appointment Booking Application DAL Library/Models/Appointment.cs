using System;
using System.Collections.Generic;

namespace Appointment_Booking_Application_DAL_Library.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string? Status { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
