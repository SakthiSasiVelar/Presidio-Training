using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_DAL_Library.Models;

namespace Appointment_Booking_Application_DAL_Library
{
    public class PatientRepository : IRepository<int, Patient>
    {
        AppointmentBookingDbContext context;

        public PatientRepository()
        {
            context = new AppointmentBookingDbContext();
        }

        public Patient Add(Patient patient)
        {
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                return patient;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Patient Delete(int key)
        {
            try
            {
                Patient patient = context.Patients.SingleOrDefault(x => x.PatientId == key);
                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    return patient;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Patient Get(int key)
        {
            try
            {
                Patient result = context.Patients.SingleOrDefault(x => x.PatientId == key);
                if (result != null)
                {
                    context.SaveChanges();
                    return result;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Patient> GetAll()
        {
            try
            {
                List<Patient> result = context.Patients.ToList();
                context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Patient Update(Patient item)
        {
            try
            {
                context.Patients.Update(item);
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
