using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using EmployeeTracker.Models.DTOs;
using EmployeeTracker.Repositories;

namespace EmployeeTracker.Services
{
    public class RequestServiceBL : IRequestService
    {
        private readonly IRepository<int,Request> _requestRepository;
        private readonly EmployeeRequestRaisedRepository _employeeRequestRaisedRepository;

        public RequestServiceBL(IRepository<int, Request> requestRepository , EmployeeRequestRaisedRepository employeeRequestRaisedRepository)
        {
            _requestRepository = requestRepository;
            _employeeRequestRaisedRepository = employeeRequestRaisedRepository;
        }

        public async Task<int> RaiseRequest(RaiseRequestDTO raiseRequestDTO)
        {
            try
            {
                var request = await RaiseRequestDTOtoRequest(raiseRequestDTO);
                var addedRequest = await _requestRepository.Add(request);
                if(addedRequest != null)
                {
                    return addedRequest.Id;
                }
                throw new Exception("Cannot get the added Request details");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in raising the request");
            }
        }

        public async Task<List<RequestReturnDTO>> GetAllRequestById(int id)
        {
            try
            {
                var employee = await _employeeRequestRaisedRepository.GetById(id);
                if(employee != null)
                {
                   var requestRaisedList =  await RequestToRequestReturnDTO(employee.RequestRaised.ToList());
                    var requestClosedList = await RequestToRequestReturnDTO(employee.RequestClosed.ToList());
                    var result = requestRaisedList.Concat(requestClosedList).ToList();
                    return result;
                }
                throw new Exception("Cannot get the employee details");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in getting request list");
            }
        }

        public async Task<List<RequestReturnDTO>> GetAllOpenRequest()
        {
            try
            {
                var allRequestList = await _requestRepository.GetAll();
                var openRequestList = allRequestList
                                        .Where(request => request.RequestStatus == "open")
                                        .OrderBy(request => request.RaisedDateTime)
                                        .ToList();
                return await RequestToRequestReturnDTO(openRequestList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in getting all open request");
            }
        }

        private async Task<Request> RaiseRequestDTOtoRequest(RaiseRequestDTO raiseRequestDTO)
        {
            Request request = new Request()
            {
                Description = raiseRequestDTO.RequestMessage,
                RequestStatus = "open",
                RaisedDateTime = raiseRequestDTO.RaisedDateTime,
                RaisedBy = raiseRequestDTO.RaisedBy,
                
            };
            return request;
        }

        private async Task<List<RequestReturnDTO>> RequestToRequestReturnDTO(List<Request> request)
        {
            List<RequestReturnDTO> RequestReturnDTOList = new List<RequestReturnDTO>();
            foreach(var  item in request)
            {
                RequestReturnDTO requestReturnDTO = new RequestReturnDTO()
                {
                    Id = item.Id,
                    Description = item.Description,
                    RaisedBy = item.RaisedBy,
                    RaisedDateTime = item.RaisedDateTime,
                    ClosedBy = item.ClosedBy,
                    ClosedDateTime = item.ClosedDateTime,
                    RequestStatus = item.RequestStatus,

                };
                RequestReturnDTOList.Add(requestReturnDTO);
            }
            return RequestReturnDTOList;
        }
    }
}
