using ClinicManagementApp.Models;

namespace ClinicManagementApp.Services
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorById(int id);

        Task<int> AddDoctor(Doctor doctor);

        Task<List<Doctor>> GetDoctorBySpecialization(string specialization);
    }
}
