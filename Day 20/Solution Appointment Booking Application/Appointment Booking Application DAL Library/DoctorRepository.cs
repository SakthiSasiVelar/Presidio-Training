
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Appointment_Booking_Application_DAL_Library.Models;

namespace Appointment_Booking_Application_DAL_Library
{
    public class DoctorRepository :IRepository<int , Doctor>
    {
        AppointmentBookingDbContext context;
        public DoctorRepository()
        {
            context = new AppointmentBookingDbContext();
        }

       
        public Doctor Add(Doctor doctor)
        {
            try
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return doctor;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Doctor Delete(int key)
        {
            try
            {
                Doctor doctor = context.Doctors.SingleOrDefault(x => x.DoctorId == key);
                if (doctor != null)
                {
                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                    return doctor;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Doctor Get(int key)
        {
            try
            {
                Doctor result = context.Doctors.SingleOrDefault(x => x.DoctorId == key);
                if (result != null)
                {
                    context.SaveChanges();
                    return result;
                }
               return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  

        public List<Doctor> GetAll()
        {
            try
            {
                List<Doctor> result = context.Doctors.ToList();
                context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Doctor Update(Doctor doctor)
        {
            try
            {
                context.Doctors.Update(doctor);
                context.SaveChanges();
                return doctor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
