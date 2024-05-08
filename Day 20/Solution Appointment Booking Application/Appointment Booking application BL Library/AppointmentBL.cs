using Appointment_Booking_Application_DAL_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_DAL_Library.Models;
using AB_Appication_BL_Custom_Exception_Library;

namespace Appointment_Booking_application_BL_Library
{
    public class AppointmentBL : IAppointmentService
    {
        AppointmentBookingDbContext context;

        public AppointmentBL()
        {
            context = new AppointmentBookingDbContext();
        }

        public int AddAppointment(Appointment appointment)
        {
            try
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return appointment.AppointmentId;
            }
            catch(Exception ex) {
                throw new AddAppointmentDetailsException();
            }
            
        }

        public int DeleteAppointment(int appointmentId)
        {
            try
            {
                Appointment appointment = context.Appointments.SingleOrDefault(x => x.AppointmentId == appointmentId);
                context.Appointments.Remove(appointment);
                context.SaveChanges();
                return appointment.AppointmentId;
            }
            catch(Exception ex)
            {
                throw new DeleteAppointmentDetailsException();
            }
            
        }

        public List<Appointment> GetAllAppointments()
        {
            try
            {
                List<Appointment> appointments = context.Appointments.ToList();
                context.SaveChanges();
                return appointments;
            }
            catch(Exception ex)
            {
                throw new GetAllAppointmentException();
            }
            

        }

        public Appointment GetByAppointmentId(int appointmentId)
        {
            try
            {
                Appointment appointment = context.Appointments.SingleOrDefault(x => x.AppointmentId == appointmentId);
               if(appointment != null)
                {
                    context.SaveChanges();
                    return appointment;
                }
               throw new GetAppointmentException();
            }
            catch( Exception ex )
            {
                throw new GetAppointmentException();
            }
            
        }

        public int UpdateAppointment(Appointment appointment)
        {
            try
            {
                context.Appointments.Update(appointment);
                context.SaveChanges();
                return appointment.AppointmentId;
            }
            catch(Exception ex)
            {
                throw new UpdateAppointmentDetails();
            }
        }
    }
}
