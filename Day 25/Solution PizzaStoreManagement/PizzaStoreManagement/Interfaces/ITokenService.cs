using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user); 
    }
}
