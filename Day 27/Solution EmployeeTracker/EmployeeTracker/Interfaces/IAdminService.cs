namespace EmployeeTracker.Interfaces
{
    public interface IAdminService
    {
        Task<int> UpdateUserStatus(int userId);
    }
}
