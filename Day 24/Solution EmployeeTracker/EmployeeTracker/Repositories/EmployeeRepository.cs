using EmployeeTracker.Contexts;
using EmployeeTracker.Exceptions;
using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeTracker.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Employees.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Employee> Delete(int key)
        {
            try
            {
                var employee = await Get(key);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                throw new NoSuchEmployeeException();
            }
            catch(Exception ex)
            {
                throw new NoSuchEmployeeException();
            }
           
            
        }

        public async Task<Employee> Get(int key)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;

        }

        public async Task<Employee> Update(Employee item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Employees.Update(item);
                await _context.SaveChangesAsync();
                return employee;
            }
            throw new NoSuchEmployeeException();
        }
    }
}
