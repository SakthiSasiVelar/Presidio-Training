using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeFeedBack
    {
        Task<int> AddFeedBack(SolutionFeedback solutionFeedback);

        Task<List<SolutionFeedback>> GetFeedBack(int id);
    }
}
