using AB_Appication_BL_Custom_Exception_Library;
using Appointment_Booking_Application_DAL_Library.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking_application_BL_Library
{
    public  class PatientBL : IPatientService
    {
        AppointmentBookingDbContext context;

        public PatientBL()
        {
            context = new AppointmentBookingDbContext();
        }

        public int AddPatient(Patient patient)
        {
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                return patient.PatientId;
            }
            catch(Exception ex)
            {
                throw new AddPatientDetailsException();
            }
            
        }

        public int DeletePatient(int patientId)
        {
            try
            {
                Patient patient = context.Patients.SingleOrDefault(x => x.PatientId == patientId);
                if(patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    return patient.PatientId;
                }
                throw new DeletePatientDeatilsException();
            }
            catch(Exception ex)
            {
                throw new DeletePatientDeatilsException();
            }
            
        }

        public Patient GetPatient(int patientId)
        {
            try
            {
                Patient result = context.Patients.SingleOrDefault(x => x.PatientId == patientId);
                if (result != null)
                {
                    context.SaveChanges();
                    return result;
                }
                throw new GetPatientException();
            }
            catch(Exception ex)
            {
                throw new GetPatientException();
            }
           
        }

        public int UpdatePatient(Patient patient)
        {
            try
            {
                context.Patients.Update(patient);
                context.SaveChanges();
                return patient.PatientId;
            }
            catch(Exception ex)
            {
                throw new UpdatePatientDetailsException();
            }
               
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                List<Patient> patientList = context.Patients.ToList();
                context.SaveChanges();
                return patientList;
            }
            catch(Exception ex)
            {
                throw new GetAllPatientExceptioncs(); 
            }
           
        }
    }
}
