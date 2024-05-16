using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Mappers
{
    public class CustomerMapper
    {
        public RegisterReturnDTO CustomerToRegisterReturnDTO(Customer customer)
        {
            RegisterReturnDTO registerReturnDTO = new RegisterReturnDTO();
            registerReturnDTO.UserId = customer.UserId;
            return registerReturnDTO;
        }
    }
}
