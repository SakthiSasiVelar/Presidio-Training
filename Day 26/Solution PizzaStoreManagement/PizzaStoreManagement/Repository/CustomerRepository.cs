using Microsoft.EntityFrameworkCore;
using PizzaStoreManagement.Contexts;
using PizzaStoreManagement.Exceptions;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;

namespace PizzaStoreManagement.Repository
{
    public class CustomerRepository : IRepository<int , Customer>
    {
        private readonly PizzaStoreManagementDbContext _context;

        public CustomerRepository(PizzaStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer entity)
        {
            try
            {
                _context.Customers.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> Delete(int key)
        {
            try
            {
                var Customer = await GetById(key);
                if (Customer != null)
                {
                    _context.Customers.Remove(Customer);
                    await _context.SaveChangesAsync();
                    return Customer;
                }
                throw new CustomerNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> GetById(int key)
        {
            try
            {
                return await _context.Customers.SingleOrDefaultAsync(c => c.UserId == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> Update(Customer entity)
        {
            try
            {
                var Customer = await GetById(entity.UserId);
                if (Customer != null)
                {
                    _context.Customers.Update(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                throw new CustomerNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
