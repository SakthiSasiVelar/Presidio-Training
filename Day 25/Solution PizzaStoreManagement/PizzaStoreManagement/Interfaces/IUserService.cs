using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Interfaces
{
    public interface IUserService
    {
        Task<RegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO);

        Task<LoginReturnDTO> LoginUser(LoginDTO loginDTO);
    }
}
