using ClinicManagementApp.Models;
using ClinicManagementApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementApp.Repository
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicManagementDbContext _context;

        public DoctorRepository(ClinicManagementDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Doctor> Add(Doctor entity)
        {
            try
            {
                _context.Doctors.Add(entity);
                await _context.SaveChangesAsync();
               return entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor> Delete(Doctor entity)
        {
            try
            {
                var doctor = await GetById(entity.Id);
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    return entity;
                }
                throw new DoctorNotFoundException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Doctor>> GetAll()
        {
            try
            {
                return await _context.Doctors.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor> GetById(int key)
        {
            try
            {
                return await _context.Doctors.SingleOrDefaultAsync(doctor => doctor.Id == key);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            try
            {
                var doctor = await GetById(entity.Id);
                if(doctor != null)
                {
                    _context.Doctors.Update(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                throw new DoctorNotFoundException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
