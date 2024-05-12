using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedBackRepository : IRepository<int , SolutionFeedback>
    {
        protected RequestTrackerContext context;

        public SolutionFeedBackRepository(RequestTrackerContext context)
        {
            this.context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            try
            {
                context.Feedbacks.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            try
            {
                var entity = await GetById(key);
                if(entity != null)
                {
                    context.Feedbacks.Remove(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            try
            {
                return await context.Feedbacks.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<SolutionFeedback> GetById(int key)
        {
            try
            {
                return await context.Feedbacks.SingleOrDefaultAsync(feedback => feedback.FeedbackId == key);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            try
            {
                var exisitingEntity = await GetById(entity.FeedbackId);
                if(exisitingEntity != null)
                {
                    context.Feedbacks.Update(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
