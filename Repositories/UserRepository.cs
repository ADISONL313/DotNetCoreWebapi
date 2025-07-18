using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.Interfaces;
using UserManager.Models;
using UserManager.Utils;

namespace UserManager.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            user.UserId=Guid.NewGuid()+"";
            // 添加用户并保存
            await _appDbContext.Users.AddAsync(user);
            return await _appDbContext.SaveChangesAsync()>0;
        }
        //查询所有用户，可以条件查询
        public async Task<PagedResult<User>?> GetAllUserAsync(int pageNumber=1,int pageSize=10, string username=null,string gender=null)
        {
            IQueryable<User> query = _appDbContext.Set<User>();
            if (!string.IsNullOrEmpty(username)) { 
                query=query.Where(u=>u.Username==username);
            }
            if (!string.IsNullOrEmpty(gender)) { 
                query=query.Where(u=>u.Gender==gender);
            }
            pageNumber = Math.Max(pageNumber, 1); // 页码至少为1
            pageSize = Math.Clamp(pageSize, 1, 100); // 页大小限制在1-100之间
            int totalCount = await query.CountAsync();
            List<User> items = await query
        .OrderBy(u => u.UserId) // 必须排序，确保分页结果稳定
        .Skip((pageNumber - 1) * pageSize) // 跳过前面页的记录
        .Take(pageSize) // 获取当前页记录
        .ToListAsync();
            return new PagedResult<User>
            {
                TotalItems = totalCount,
                TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Items = items
            };
        }
        //删除用户
        public async Task<bool> DeleteUserByUserId(string userId)
        {
            int isDel = await _appDbContext.Users.Where(u => u.UserId == userId).ExecuteDeleteAsync();
            return isDel > 0;
        }
        public async Task<bool> UpdateUserByUserIdAsync(User user)
        {
            var existingUser = await _appDbContext.Users.FindAsync(user.UserId);
            existingUser.Username=user.Username;
            existingUser.Gender = user.Gender;
           existingUser.UserRole=user.UserRole;
            existingUser.Phone = user.Phone;
            int isUpdate = await _appDbContext.SaveChangesAsync();
            return (isUpdate > 0);
        }
    }
}
