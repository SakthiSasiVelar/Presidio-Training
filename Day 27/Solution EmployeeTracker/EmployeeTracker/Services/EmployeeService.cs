using EmployeeTracker.Exceptions;
using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;

namespace EmployeeTracker.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeService(IRepository<int, Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.GetAll()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.GetAll();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.GetById(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
