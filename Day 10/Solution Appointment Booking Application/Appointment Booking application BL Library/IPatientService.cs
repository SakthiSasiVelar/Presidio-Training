using Appointment_Booking_Application_Model_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_Model_Library;

namespace Appointment_Booking_application_BL_Library
{
    public interface IPatientService
    {
        public int AddPatient(Patient patient);

        public int UpdatePatient(Patient patient);

        public int DeletePatient(int patientId);

        public Patient GetPatient(int patientId);

    }
}
