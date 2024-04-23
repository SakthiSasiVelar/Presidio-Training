using AB_Appication_BL_Custom_Exception_Library;
using Appointment_Booking_Application_DAL_Library;
using Appointment_Booking_Application_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking_application_BL_Library
{
    public  class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;

        public PatientBL(IRepository<int,Patient>  repository)
        {
            _patientRepository = repository;
        }

        public int AddPatient(Patient patient)
        {
            Patient result = _patientRepository.Add(patient);  
            return result.Id;
        }

        public int DeletePatient(int patientId)
        {
            Patient result = _patientRepository.Delete(patientId);
            if (result != null)
            {
                return result.Id;
            }
            throw new DeletePatientDeatilsException();
        }

        public Patient GetPatient(int patientId)
        {
            Patient result = _patientRepository.Get(patientId);
            if (result != null)
            {
                return result;
            }
            throw new GetPatientException();
        }

        public int UpdatePatient(Patient patient)
        {
            Patient result = _patientRepository.Update(patient);
            if (result != null)
            {
                return result.Id;
            }
            throw new UpdatePatientDetailsException();
        }
    }
}
