using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : RequestRepository
    {
        public RequestSolutionRepository(RequestTrackerContext context) : base(context) { }

        public override async Task<IList<Request>> GetAll()
        {
            try
            {
                return await context.Requests.Include(r => r.RequestSolutions).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<Request> GetById(int key)
        {
            try
            {
                var request = await context.Requests.Include(r => r.RequestSolutions).SingleOrDefaultAsync(r => r.RequestNumber == key);
                return request;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
