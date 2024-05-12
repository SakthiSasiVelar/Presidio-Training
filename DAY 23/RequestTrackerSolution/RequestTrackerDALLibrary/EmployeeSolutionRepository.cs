using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeSolutionRepository :EmployeeRepository
    {
        public EmployeeSolutionRepository(RequestTrackerContext context) : base(context)
        {

        }

        public override async Task<IList<Employee>> GetAll()
        {
            try
            {
               return await _context.Employees.Include(e => e.SolutionsProvided).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<Employee> GetById(int key)
        {
            try
            {
                var employee = await _context.Employees.Include(e => e.SolutionsProvided).SingleOrDefaultAsync(e => e.Id == key);
                return employee;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
