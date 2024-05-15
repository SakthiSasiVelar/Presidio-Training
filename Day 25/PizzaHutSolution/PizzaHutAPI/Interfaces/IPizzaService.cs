using PizzaHutAPI.Models;

namespace PizzaHutAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<Pizza> Add(Pizza pizza);
        public Task<List<Pizza>> GetAvailablePizza();
    }
}
