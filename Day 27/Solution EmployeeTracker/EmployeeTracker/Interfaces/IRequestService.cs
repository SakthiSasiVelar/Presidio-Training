using EmployeeTracker.Models;
using EmployeeTracker.Models.DTOs;

namespace EmployeeTracker.Interfaces
{
    public interface IRequestService
    {
        Task<int> RaiseRequest(RaiseRequestDTO raiseRequestDTO);

        Task<List<RequestReturnDTO>> GetAllRequestById(int id);

        Task<List<RequestReturnDTO>> GetAllOpenRequest();
    }
}
