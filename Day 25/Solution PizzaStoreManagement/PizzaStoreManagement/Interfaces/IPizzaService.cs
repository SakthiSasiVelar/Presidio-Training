using PizzaStoreManagement.Models;

namespace PizzaStoreManagement.Interfaces
{
    public interface IPizzaService
    {
        Task<int> AddPizza(Pizza pizza);
        Task<List<Pizza>> GetAvailablePizza();
    }
}
