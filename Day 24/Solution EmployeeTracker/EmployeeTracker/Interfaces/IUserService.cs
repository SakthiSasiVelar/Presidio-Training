using EmployeeTracker.Models.DTOs;
using EmployeeTracker.Models;

namespace EmployeeTracker.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
