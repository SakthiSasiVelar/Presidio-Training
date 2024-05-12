using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeSolutionBL : IEmployeeSolutionBL
    {
        private readonly IRepository<int, SolutionRequest> _solutionRepository;
        private readonly IRepository<int, Employee> _employeeRequestRepository;
        private readonly IRepository<int, Request> _requestSolutionRepository;

        public EmployeeSolutionBL()
        {
            RequestTrackerContext context = new RequestTrackerContext();
            IRepository<int, Employee> employeeRequestRepo = new EmployeeRequestRepository(context);
            IRepository<int, SolutionRequest> solutionRepo = new SolutionRequestRepository(context);
            IRepository<int, Request> requestSolutionRepo = new RequestSolutionRepository(context);
            _requestSolutionRepository = requestSolutionRepo;
            _employeeRequestRepository = employeeRequestRepo;
            _solutionRepository = solutionRepo;
        }
        public async Task<int> AddSolution(SolutionRequest solutionRequest)
        {
            try
            {
                var result = await _solutionRepository.Add(solutionRequest);
                if(result != null)
                {
                    return result.SolutionId;

                }
                throw new Exception("Could not add the solution,try again");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in adding the solution,try again");
            }
        } 

        public async Task<List<SolutionRequest>> GetSolutionsByRequestId(int id)
        {
            try
            {
               Request request = await _requestSolutionRepository.GetById(id);
                if(request != null)
                {
                    return request.RequestSolutions.ToList();
                }
                throw new Exception("Invalid request id");
            }
            catch(Exception ex)
            {
                throw new Exception("Fetching solutions for request id is failed,try again");
            }
        }

        public async Task<List<SolutionRequest>> ViewSolutionsById(int id)
        {
            try
            {
                Employee employee = await _employeeRequestRepository.GetById(id);
                if (employee != null)
                {
                    List<Request> RequestList = employee.RequestsRaised.Concat(employee.RequestsClosed).ToList();
                    List<SolutionRequest> Solutions = new List<SolutionRequest>();
                    foreach (Request request in RequestList)
                    {
                        List<SolutionRequest> solutionRequestList = await GetSolutionsByRequestId(request.RequestNumber);
                        Solutions.AddRange(solutionRequestList);
                    }
                    return Solutions;
                    
                }
                throw new Exception("Employee details not available");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in getting request list,please try again");
            }
        }

        public async Task<IList<SolutionRequest>> ViewAllSolutions()
        {
            try
            {
                return await _solutionRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw new Exception("Error in fetching solutions,please try again ");
            }
        }

        public async Task<int> AddRespondToSolution(SolutionRequest solutionRequest)
        {
            try
            {
                var updatedSolutionRequest = await _solutionRepository.Update(solutionRequest);
                if(updatedSolutionRequest != null)
                {
                    return updatedSolutionRequest.SolutionId;
                }
                throw new Exception("Solution id not found");
            }
            catch(Exception ex)
            {
                throw new Exception("error in adding reponse to solution");
            }
        }

        public async Task<SolutionRequest> GetSolutionById(int id)
        {
            try
            {
                var solution = await _solutionRepository.GetById(id);
                if(solution != null)
                {
                    return solution;
                }
                throw new Exception("No solution found");
            }
            catch(Exception ex) {
                throw new Exception("Error in getting solution");
            }
        }
    }
}
