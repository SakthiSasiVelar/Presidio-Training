using AB_Appication_BL_Custom_Exception_Library;

using Appointment_Booking_Application_DAL_Library.Models;

namespace Appointment_Booking_application_BL_Library
{
    public class DoctorBL : IDoctorService
    {

        AppointmentBookingDbContext context;

        public DoctorBL(AppointmentBookingDbContext setContext)
        {
            context = setContext;
        }

        public int AddDoctor(Doctor doctor)
        {
            try
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return doctor.DoctorId;
            }
            catch (Exception ex)
            {
                throw new AddDoctorDetailsException();
            }   
        }

        public int DeleteDoctor(int doctorId)
        {
            try
            {
                Doctor doctor = context.Doctors.SingleOrDefault(x =>  x.DoctorId == doctorId);
                if(doctor != null)
                {
                    context.Doctors.Remove(doctor);
                    context.SaveChanges();
                    return doctor.DoctorId;
                }
                throw new DeleteDoctorDetailsException();
            }
            catch (Exception e)
            {
                throw new DeleteDoctorDetailsException();
            }   
        }

        public List<Doctor> GetAllDoctors()
        {
            try
            {
                List<Doctor> result = context.Doctors.ToList();
                context.SaveChanges();
                return result;
            }
            catch(Exception ex)
            {
               throw new GetAllDoctorException();
            }  
        }

        public Doctor GetDoctor(int doctorId)
        {

            try
            {
                Doctor result = context.Doctors.SingleOrDefault(x => x.DoctorId == doctorId);
                if (result != null)
                {
                    context.SaveChanges();
                    return result;
                }
                throw new GetDoctorException();
            }
            catch(Exception ex)
            {
                throw new GetDoctorException();
            }
        }

        public int UpdateDoctor(Doctor doctor)
        {
            try
            {
                context.Doctors.Update(doctor);
                context.SaveChanges();
                return doctor.DoctorId;
            }
            catch(Exception ex)
            {
               throw new UpdateDoctorDeatilsException();
            }  
        }
    }
}
