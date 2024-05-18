using EmployeeTracker.Models;

namespace EmployeeTracker.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
