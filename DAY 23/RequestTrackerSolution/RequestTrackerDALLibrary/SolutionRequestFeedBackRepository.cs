using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionRequestFeedBackRepository : SolutionRequestRepository
    {
        public SolutionRequestFeedBackRepository(RequestTrackerContext context) : base(context) { } 

        public override async Task<IList<SolutionRequest>> GetAll()
        {
            try
            {
                return await context.Solutions.Include(s => s.Feedbacks).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<SolutionRequest> GetById(int key)
        {
            try
            {
                return await context.Solutions.Include(s => s.Feedbacks).SingleOrDefaultAsync(solution => solution.SolutionId == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
