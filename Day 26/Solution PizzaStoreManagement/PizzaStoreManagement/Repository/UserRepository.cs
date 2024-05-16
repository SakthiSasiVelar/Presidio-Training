using Microsoft.EntityFrameworkCore;
using PizzaStoreManagement.Contexts;
using PizzaStoreManagement.Exceptions;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;

namespace PizzaStoreManagement.Repository
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaStoreManagementDbContext _context;

        public UserRepository(PizzaStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Delete(int key)
        {
            try
            {
                var user = await GetById(key);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                throw new UserNotFoundException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetById(int key)
        {
            try
            {
                return await _context.Users.SingleOrDefaultAsync(user => user.Id == key);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                var user = await GetById(entity.Id);
                if (user != null)
                {
                    _context.Users.Update(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                throw new UserNotFoundException();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
