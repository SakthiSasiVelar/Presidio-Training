using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeRequestBL : IEmployeeRequestBL
    {
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, Employee> _employeeRequestRepository;

        public EmployeeRequestBL()
        {
            RequestTrackerContext context = new RequestTrackerContext();
            IRepository<int, Request> requestRepo = new RequestRepository(context);
            IRepository<int, Employee> employeeRequestRepo = new EmployeeRequestRepository(context);
            _requestRepository = requestRepo;
            _employeeRequestRepository = employeeRequestRepo;
        }

        public EmployeeRequestBL(EmployeeRequestRepository employeeRequestRepository) 
        {
            _employeeRequestRepository = employeeRequestRepository;
        }

        public async Task<int> AddRequest(Request request)
        {
            try
            {
                var requestResult = await _requestRepository.Add(request);
                if (requestResult != null)
                {
                    return requestResult.RequestNumber;
                }
                throw new Exception("Request not raised , please try again");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Request not raised , please try again");
            }
        }

        public async Task<List<Request>> ViewRequest(int id)
        {
            try
            {
                Employee employee = await _employeeRequestRepository.GetById(id);
                if (employee != null)
                {
                    List<Request> RequestList = employee.RequestsRaised.Concat(employee.RequestsClosed).ToList();
                    return RequestList;
                }
                throw new Exception("Employee details not available");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in fetching Request,please try again");
            }
        }

        public async Task<List<Request>> ViewAllOpenRequest()
        {
            try
            {
                var requestList = await ViewAllRequest();
                List<Request> openRequestlist = new List<Request>();
                foreach(var request in requestList)
                {
                    if(request.RequestStatus == "open") { openRequestlist.Add(request); }
                }
                return openRequestlist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in fetching open Request list,please try again");
            }
        }

        public async Task<IList<Request>> ViewAllRequest()
        {
            try
            {
                return await _requestRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("error in getting solutions");
            }
        }

        public async Task<int> CloseRequest(int id , int EmployeeId)
        {
            try
            {
                var request = await _requestRepository.GetById(id);
                if (request != null) 
                {
                    request.RequestStatus = "close";
                    request.RequestClosedBy = EmployeeId;
                    var updatedRequest = await _requestRepository.Update(request);
                    return updatedRequest.RequestNumber;
                }
                throw new Exception("Request details not available");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in closing the request");
            }
        }
    }
}
