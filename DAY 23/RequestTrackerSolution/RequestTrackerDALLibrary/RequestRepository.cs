using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository  : IRepository<int,Request>
    {
        protected RequestTrackerContext context;

        public RequestRepository(RequestTrackerContext context)
        {
            this.context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            try
            {
                context.Requests.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Request> Delete(int key)
        {
            try
            {
                var entity = await GetById(key);
                if(entity != null)
                {
                    context.Requests.Remove(entity);
                    await context.SaveChangesAsync();
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

        public virtual async Task<Request> GetById(int key)
        {
            try
            {
                return context.Requests.SingleOrDefault(r => r.RequestNumber == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

        public virtual async Task<IList<Request>> GetAll()
        {
            try
            {
                return await context.Requests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Request> Update(Request entity)
        {
            try
            {
                var request = await GetById(entity.RequestNumber);
                if(request != null)
                {
                    context.Requests.Update(entity);
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
