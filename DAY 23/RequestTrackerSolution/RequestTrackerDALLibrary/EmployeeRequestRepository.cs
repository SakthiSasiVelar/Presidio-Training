using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRequestRepository : EmployeeRepository
    {
        public EmployeeRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public  async override Task<IList<Employee>> GetAll()
        {
            try
            {
                return await _context.Employees
                    .Include(e => e.RequestsRaised)
                    .Include(e => e.RequestsClosed)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async override Task<Employee> GetById(int key)
        {
            try
            {
                var employee = await _context.Employees
                    .Include(e => e.RequestsRaised)
                    .Include(e => e.RequestsClosed)
                    .SingleOrDefaultAsync(e => e.Id == key);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
