using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<Pizza> Add(Pizza pizza)
        {
            return await _repository.Add(pizza);
        }

        public async Task<List<Pizza>> GetAvailablePizza()
        {
            try
            {
                var pizzaList = await _repository.GetAll();
                List<Pizza> availablePizza = new List<Pizza>();
                foreach(var item in pizzaList)
                {
                    if(item.QtyInHand > 0)
                    {
                        availablePizza.Add(item);
                    }
                }
                return availablePizza;
            }
            catch(Exception ex)
            {
                throw new Exception("error in getting available pizza");
            }
        }
    }
}
