using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;

namespace EmployeeTracker.Services
{
    public class AdminServiceBL : IAdminService
    {
        private readonly IRepository<int, User> _userRepository;

        public AdminServiceBL(IRepository<int, User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> UpdateUserStatus(int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if(user != null)
                {
                    user.Status = "active";
                    var updatedUser = await _userRepository.Update(user);
                    if(updatedUser != null)
                    {
                        return updatedUser.EmployeeId;
                    }
                    throw new Exception("Cannot get the updated user details");
                }
                throw new Exception("Cannot get the user");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in updating status of the user");
            }
        }
    }
}
