using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaStoreManagement.Mappers
{
    public class UserRegisterDTOMapper
    {
        public Customer UserRegisterDTOtoCustomer(UserRegisterDTO user)
        {
            Customer customer = new Customer();
            HMACSHA512 hMACSHA = new HMACSHA512();
            customer.PasswordHashKey = hMACSHA.Key;
            customer.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            return customer;

        }
    }
}
