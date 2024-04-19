using AB_Appication_BL_Custom_Exception_Library;

using Appointment_Booking_Application_DAL_Library;

using Appointment_Booking_Application_Model_Library;

namespace Appointment_Booking_application_BL_Library
{
    public class DoctorBL : IDoctorService
    {
        readonly DoctorRepository _doctorRepository;

        public DoctorBL()
        {
            _doctorRepository = new DoctorRepository();
        }

        public int AddDoctor(Doctor doctor)
        {
            Doctor result = _doctorRepository.Add(doctor);
            if(result != null)
            {
                return result.Id;
            }  
            throw new AddDoctorDetailsException();
        }

        public int DeleteDoctor(int doctorId)
        {
            Doctor result = _doctorRepository.Delete(doctorId);
            if(result != null)
            {
                return result.Id;
            }
            throw new DeleteDoctorDetailsException();
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> result = _doctorRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new GetAllDoctorException();
        }

        public Doctor GetDoctor(int doctorId)
        {
            Doctor result = _doctorRepository.Get(doctorId);
            if(result != null)
            {
                return result;
            }
            throw new GetDoctorException();
        }

        public int UpdateDoctor(Doctor doctor)
        {
            Doctor result = _doctorRepository.Update(doctor);
            if(result != null)
            {
                return result.Id;
            }
            throw new UpdateDoctorDeatilsException();
        }
    }
}
