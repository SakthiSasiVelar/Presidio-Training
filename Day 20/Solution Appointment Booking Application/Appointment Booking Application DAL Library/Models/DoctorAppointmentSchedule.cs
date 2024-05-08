using System;
using System.Collections.Generic;

namespace Appointment_Booking_Application_DAL_Library.Models
{
    public partial class DoctorAppointmentSchedule
    {
        public int? DoctorId { get; set; }
        public DateTime? ScheduleList { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
