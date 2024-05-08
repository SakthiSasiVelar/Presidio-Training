using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_DAL_Library.Models;

namespace Appointment_Booking_application_BL_Library
{
    public  interface IAppointmentService
    {
        public int AddAppointment(Appointment appointment);
        public int UpdateAppointment(Appointment appointment);

        public int DeleteAppointment(int appointmentId);

        public List<Appointment> GetAllAppointments();

        public Appointment GetByAppointmentId(int appointmentId);
    }
}
