using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using System.Linq.Expressions;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context) 
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            try
            {
                _context.Employees.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Employee> Delete(int key)
        {
            try
            {
                var employee = await GetById(key);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }    
        }

        public virtual async Task<Employee> GetById(int key)
        {
            try
            {
                var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == key);
                return employee;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<Employee> Update(Employee entity)
        {
            try
            {
                var employee = await GetById(entity.Id);
                if (employee != null)
                {
                    _context.Entry<Employee>(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
