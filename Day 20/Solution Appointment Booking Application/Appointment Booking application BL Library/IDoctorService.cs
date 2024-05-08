
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Appointment_Booking_Application_DAL_Library.Models;

namespace Appointment_Booking_application_BL_Library
{
    public interface IDoctorService
    {
        public int AddDoctor(Doctor doctor);

        public int UpdateDoctor(Doctor doctor);

        public int DeleteDoctor(int doctorId);

        public Doctor GetDoctor(int doctorId);

        public List<Doctor> GetAllDoctors();
    }
}
