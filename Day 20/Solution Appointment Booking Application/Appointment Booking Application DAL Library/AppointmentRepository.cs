
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_DAL_Library.Models;


namespace Appointment_Booking_Application_DAL_Library
{
    public class AppointmentRepository
    {
        AppointmentBookingDbContext context;

        public AppointmentRepository()
        {
            context = new AppointmentBookingDbContext();
        }

        public Appointment Add(Appointment item)
        {
            try
            {
                context.Appointments.Add(item);
                context.SaveChanges();
                return item;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public Appointment Delete(int key)
        {
            try
            {
                Appointment appointment = context.Appointments.SingleOrDefault(x => x.AppointmentId == key);
                context.Appointments.Remove(appointment);
                context.SaveChanges();
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Appointment Get(int key)
        {
            try
            {
                Appointment appointment = context.Appointments.SingleOrDefault(x => x.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    context.SaveChanges();
                    return appointment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Appointment> GetAll()
        {
            try
            {
                List<Appointment> appointments = context.Appointments.ToList();
                context.SaveChanges();
                return appointments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Appointment Update(Appointment item)
        {
            try
            {
                context.Appointments.Update(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
