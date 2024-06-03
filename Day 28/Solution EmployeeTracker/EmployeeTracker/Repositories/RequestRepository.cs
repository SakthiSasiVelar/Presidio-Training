using EmployeeTracker.Contexts;
using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext requestTrackerContext)
        {
            _context = requestTrackerContext;
        }

         public async Task<Request> Add(Request item)
         {
            try
            {
                _context.Requests.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
         }

        public async Task<Request> Delete(int key)
        {
            try
            {
                var item = await GetById(key);
                if (item != null)
                {
                    _context.Requests.Remove(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new Exception("Cannot get item details");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Request> Update(Request item)
        {
            try
            {
                var user = await GetById(item.Id);
                if (user != null)
                {
                    _context.Requests.Update(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new Exception("Cannot get item details");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
        }

        public async Task<Request> GetById(int key)
        {
            try
            {
                return await _context.Requests.SingleOrDefaultAsync(r => r.Id == key);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            try
            {
                return await _context.Requests.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
