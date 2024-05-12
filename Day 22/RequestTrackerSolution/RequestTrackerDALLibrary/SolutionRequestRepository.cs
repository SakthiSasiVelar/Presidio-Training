using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionRequestRepository : IRepository<int , SolutionRequest>
    {
        protected RequestTrackerContext context;

        public SolutionRequestRepository(RequestTrackerContext context)
        {
            this.context = context;
        }

        public async Task<SolutionRequest> Add(SolutionRequest entity)
        {
            try
            {
                context.Solutions.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<SolutionRequest> Delete(int key)
        {
            try
            {
                var entity = await GetById(key);
                if (entity != null)
                {
                    context.Solutions.Remove(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<IList<SolutionRequest>> GetAll()
        {
            try
            {
                return await context.Solutions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<SolutionRequest> GetById(int key)
        {
            try
            {
                return await context.Solutions.SingleOrDefaultAsync(solution => solution.SolutionId == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SolutionRequest> Update(SolutionRequest entity)
        {
            try
            {
                var exisitingEntity = await GetById(entity.SolutionId);
                if (exisitingEntity != null)
                {
                    context.Solutions.Update(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
