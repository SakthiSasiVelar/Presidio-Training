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
            return await _context.Employees.Include(e => e.SolutionsProvided).ToListAsync();
        }

        public override async Task<Employee> Get(int key)
        {
            var employee = await._context.Employees.Include(e => e.SolutionsProvided).SingleOrDefault(e => e.Id == key);
            return employee;
        }
    }
}
