using Microsoft.EntityFrameworkCore;
using PizzaStoreManagement.Contexts;
using PizzaStoreManagement.Exceptions;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;

namespace PizzaStoreManagement.Repository
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaStoreManagementDbContext _context;

        public PizzaRepository(PizzaStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza entity)
        {
            try
            {
                _context.Pizzas.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pizza> Delete(int key)
        {
            try
            {
                var Pizza = await GetById(key);
                if (Pizza != null)
                {
                    _context.Pizzas.Remove(Pizza);
                    await _context.SaveChangesAsync();
                    return Pizza;
                }
                throw new PizzaNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Pizza>> GetAll()
        {
            try
            {
                return await _context.Pizzas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pizza> GetById(int key)
        {
            try
            {
                return await _context.Pizzas.SingleOrDefaultAsync(pizza => pizza.Id == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            try
            {
                var Pizza = await GetById(entity.Id);
                if (Pizza != null)
                {
                    _context.Pizzas.Update(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                throw new PizzaNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
