﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking_Application_Model_Library
{
    public class Appointment
    {
        public int Id {  get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public string AppointmentStatus { get; set;}
    }
}
