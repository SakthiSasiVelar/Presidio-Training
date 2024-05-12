using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeSolutionBL
    {
        Task<int> AddSolution(SolutionRequest solutionRequest);
        Task<List<SolutionRequest>> ViewSolutionsById(int id);
        Task<IList<SolutionRequest>> ViewAllSolutions();
        Task<int> AddRespondToSolution(SolutionRequest solutionRequest);
        Task<SolutionRequest> GetSolutionById(int id);
    }
}
