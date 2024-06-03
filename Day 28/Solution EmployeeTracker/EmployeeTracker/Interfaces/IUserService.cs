using EmployeeTracker.Models.DTOs;
using EmployeeTracker.Models;

namespace EmployeeTracker.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
