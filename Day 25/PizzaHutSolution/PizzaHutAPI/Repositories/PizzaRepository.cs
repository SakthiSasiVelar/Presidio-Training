using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Context;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Models;
using PizzaHutAPI.Interfaces;

namespace PizzaHutAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly DBPizzaHutContext _context;
        public PizzaRepository(DBPizzaHutContext context )
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            try
            {
                _context.Pizzas.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Insert the new Pizza");
            }
        }


        public async Task<Pizza> Get(int key)
        {
            try
            {
                return (await _context.Pizzas.SingleOrDefaultAsync(p => p.Id == key)) ?? throw new NoPizzaInThisID(key);
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Get the Pizza");
            }
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            try
            {
                var res = await _context.Pizzas.ToListAsync();
                if (res.Count > 0)
                    return res;
                throw new EmptyDBException("Pizza");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pizza> Update(Pizza item)
        {
            try
            {
                _context.Pizzas.Update(item);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return  item;
                throw new AlreadyUpToDateException(item.Id);
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Update the Pizza");
            }
        }
        public async Task<Pizza> Delete(int key)
        {
            try
            {
                var pizza = await Get(key);
                if(pizza != null)
                {
                    _context.Pizzas.Add(pizza);
                    await _context.SaveChangesAsync();
                    return pizza;
                }
                throw new Exception("pizza details not available");
                
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Delete the Pizza");
            }
        }
    }
}
