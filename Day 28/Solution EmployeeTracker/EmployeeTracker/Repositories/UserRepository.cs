using EmployeeTracker.Contexts;
using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracker.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private RequestTrackerContext _context;

        public UserRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            item.Status = "Disabled";
            _context.Users.Add(item);
           await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await GetById(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }

        public async Task<User> GetById(int key)
        {
            return (await _context.Users.SingleOrDefaultAsync(u => u.EmployeeId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await GetById(item.EmployeeId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
    }
}
