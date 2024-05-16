using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Mappers;
using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;
using PizzaStoreManagement.Repository;
using System.Security.Cryptography;
using System.Text;

namespace PizzaStoreManagement.Services
{
    public class UserServiceBL : IUserService
    {
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IRepository<int, User> _userRepository;
        private readonly ITokenService _tokenService;

        public UserServiceBL(IRepository<int, Customer> customerRepository, IRepository<int, User> userRepository , ITokenService tokenService)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginReturnDTO> LoginUser(LoginDTO loginDTO)
        {
            try
            {
                var userInDb = await _customerRepository.GetById(loginDTO.UserId);
                if(userInDb != null)
                {
                    HMACSHA512 hMACSHA512 = new HMACSHA512(userInDb.PasswordHashKey);
                    var encryptPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                    var isPasswordSame = ComparePassword(encryptPassword , userInDb.Password);
                    if(isPasswordSame)
                    {
                        var user = await _userRepository.GetById(loginDTO.UserId);
                        if(user != null)
                        {
                            var token = await _tokenService.GenerateToken(user);
                            if(token != null)
                            {
                                return new UserMapper().userToLoginReturnDTO(user, token);
                            }
                            throw new Exception("Token not genrated");
                        }
                        throw new Exception("User unavailable");
                        
                    }
                    throw new Exception("Invalid password");
                }
                throw new Exception("Invalid username");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in login");
            }
        }

        public async Task<RegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            User user = null;
            Customer customer = null;
            try
            {
                user = userRegisterDTO;
                user = await _userRepository.Add(user);
                if(user != null)
                {
                    customer = new UserRegisterDTOMapper().UserRegisterDTOtoCustomer(userRegisterDTO);
                    customer.UserId = user.Id;
                    customer = await _customerRepository.Add(customer);
                    if(customer != null)
                    {
                        return new CustomerMapper().CustomerToRegisterReturnDTO(customer);
                    }
                }
                throw new Exception("Error in adding user registeration");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in adding user registeration");
            }
            finally
            {
                if(customer != null && user == null) await RevertCustomerRegisteration(customer.UserId);
                else if(user != null && customer == null) await RevertUserRegisteration(user.Id);
            }
        }

        public async Task RevertCustomerRegisteration(int id)
        {
            try
            {
                await _customerRepository.Delete(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("error in reverting customer registeration");
            }
        }

        public async Task RevertUserRegisteration(int id)
        {
            try
            {
                 await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("error in reverting user registeration");
            }
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
