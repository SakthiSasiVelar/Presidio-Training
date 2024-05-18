using EmployeeTracker.Contexts;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Repositories
{
    public class EmployeeRequestRaisedRepository  : EmployeeRepository
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRequestRaisedRepository(RequestTrackerContext context): base(context) {
            _context = context;
        }

        public override async Task<Employee> GetById(int id)
        {
            try
            {
                return await _context.Employees.Include(e => e.RequestRaised).SingleOrDefaultAsync(e => e.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await _context.Employees.Include(e => e.RequestRaised).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
