using UserManager.Models;

namespace UserManager.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> AddUserAsync(User user);
        Task<PagedResult<User>?> GetAllUserAsync(int pageNumber = 1, int pageSize = 10, string username = null, string gender = null);
        Task<bool> DeleteUserByUserId(string userId);
        Task<bool> UpdateUserByUserIdAsync(User user);
    }
}
