using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeFeedBackBL : IEmployeeFeedBack
    {
        IRepository<int,SolutionFeedback> _feedbackRepository;
        IRepository<int, Employee> _employeeSolutionRepository;
        IRepository<int, SolutionRequest> _solutionRequestFeedBackRepository;

        public EmployeeFeedBackBL()
        {
            RequestTrackerContext context = new RequestTrackerContext();
            IRepository<int, SolutionFeedback> feedBackrepo = new SolutionFeedBackRepository(context);
            IRepository<int, Employee> employeeSolutionrepo = new EmployeeSolutionRepository(context);
            IRepository<int, SolutionRequest> solutionRequestFeedBackRepo = new SolutionRequestFeedBackRepository(context);
            _solutionRequestFeedBackRepository = solutionRequestFeedBackRepo;
            _feedbackRepository = feedBackrepo;
            _employeeSolutionRepository = employeeSolutionrepo;
        }
        public async Task<int> AddFeedBack(SolutionFeedback solutionFeedback)
        {
            try
            {
                var result = await _feedbackRepository.Add(solutionFeedback);
                if(result != null)
                {
                    return result.FeedbackId;
                }
                throw new Exception("Could not add the feedback , try again");
            }
            catch(Exception ex)
            {
                throw new Exception("Error in adding the feedback , try again");
            }
        }

        public async Task<List<SolutionFeedback>> GetFeedBack(int id)
        {
            try
            {
                Employee employee = await _employeeSolutionRepository.GetById(id);
                if(employee != null)
                {
                     List<SolutionRequest> solutionsProvided = employee.SolutionsProvided.ToList();
                     List<SolutionFeedback> feedbacks = new List<SolutionFeedback>();
                    foreach(var solution in solutionsProvided)
                    {
                        SolutionRequest solutionRequest = await _solutionRequestFeedBackRepository.GetById(solution.SolutionId);
                        feedbacks.AddRange(solutionRequest.Feedbacks.ToList());
                        
                    }
                    return feedbacks;
                }
                throw new Exception("Could find employee details");

            }
            catch(Exception ex)
            {
                throw new Exception("Error in fetching feedback of the employee");
            }
        }
    }
}
