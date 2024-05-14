using ClinicManagementApp.Exceptions;
using ClinicManagementApp.Models;
using ClinicManagementApp.Repository;

namespace ClinicManagementApp.Services
{
    public class DoctorServiceBL : IDoctorService
    {
        private readonly IRepository<int,Doctor> _doctorRepository;

        public DoctorServiceBL(ClinicManagementDbContext context)
        {
            IRepository<int, Doctor> doctorRepo = new DoctorRepository(context);
            _doctorRepository = doctorRepo;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorRepository.GetById(id);
                return doctor;
            }
            catch(Exception ex){
                throw new Exception("Doctor details not found");
            }
            
        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
            try
            {
                var addDoctor = await _doctorRepository.Add(doctor);
                if(addDoctor != null)
                {
                    return addDoctor.Id;
                }
                throw new DoctorNotFoundException();
            }
            catch(Exception ex)
            {
                throw new Exception("Error in adding doctor details");
            }
        }

        public async Task<List<Doctor>> GetDoctorBySpecialization(string specialization)
        {
            try
            {
                var allDoctorslist = await _doctorRepository.GetAll();
                List<Doctor> doctorListBySpecialization = new List<Doctor>();

                foreach(var doctor in allDoctorslist)
                {
                    if (doctor.Specialization == specialization) doctorListBySpecialization.Add(doctor);

                }
                return doctorListBySpecialization;
             
            }
            catch(Exception ex)
            {
                throw new Exception("Error in fetching doctor details by given specialization");
            }
        }
    }
}
