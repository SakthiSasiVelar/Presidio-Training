using System;
using System.Collections.Generic;

namespace LearnLINQApp.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string? Status { get; set; }
    }
}
