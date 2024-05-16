using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Mappers
{
    public class UserMapper
    {
        public LoginReturnDTO userToLoginReturnDTO(User user , string token)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
            loginReturnDTO.Token = token;
            loginReturnDTO.LoginId = user.Id;
            return loginReturnDTO;
        }
    }
}
