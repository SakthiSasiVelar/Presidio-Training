using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;
using PizzaStoreManagement.Repository;

namespace PizzaStoreManagement.Services
{
    public class PizzaSeviceBL : IPizzaService
    {
        private readonly IRepository<int,Pizza> _pizzaRepository;

        public PizzaSeviceBL(IRepository<int, Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<int> AddPizza(Pizza pizza)
        {
            try
            {
                var addedPizza = await _pizzaRepository.Add(pizza);
                if(addedPizza != null)
                {
                    return addedPizza.Id;
                }
                throw new Exception("Cannot get added pizza details");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in adding pizza");
            }
        }

        public async Task<List<Pizza>> GetAvailablePizza()
        {
            try
            {
                var allPizzaList = await _pizzaRepository.GetAll();
                List<Pizza> availablePizzaList = new List<Pizza>();
                foreach (var pizza in allPizzaList)
                {
                    if (pizza.Quantity > 0)
                    {
                        availablePizzaList.Add(pizza);
                    }
                }
                return availablePizzaList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("error in fetching available pizza list");
            }
        }
    }
}
