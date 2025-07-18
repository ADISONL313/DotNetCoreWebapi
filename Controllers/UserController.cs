using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserManager.Dtos.User;
using UserManager.Interfaces;
using UserManager.Models;
using UserManager.Utils;

namespace UserManager.Controllers
{
    [Route("UM/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly JwtTokenService _jwtTokenService;
        public UserController(IUserRepository userRepository, IConfiguration configuration,JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtTokenService = jwtTokenService;
        }
        //注册接口
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null) {
                return Ok(ResultHelper.Failed("数据不完整",false));
            }
            if (await _userRepository.GetUserByEmailAsync(registerDto.Email) != null) {
                return Ok(ResultHelper.Failed("用户已存在",false));
            }
            var hashPassword = PasswordEncode.HashEncode(registerDto.password==""?"123456asd":registerDto.password);
            var user = new User
            {
                Username = registerDto.Username,
                Password = hashPassword,
                Email = registerDto.Email,
                UserRole = registerDto.UserRole==""?"普通用户":registerDto.UserRole,
                CreateAt = DateTime.Now,
                Phone=registerDto.phone,
                Gender = registerDto.gender,
            };
            if (!await _userRepository.AddUserAsync(user)) {
                return Ok(ResultHelper.Failed("注册失败", false));
            }
            return Ok(ResultHelper.Success("注册成功"));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return Ok(ResultHelper.Failed("数据不完整", false));
            }
            var searchResult=await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (searchResult == null)
            {
                return Ok(ResultHelper.Failed("用户不存在", false));
            }
            if (!PasswordEncode.VerifyPassword(loginDto.Password,searchResult.Password))
            {
                return Ok(ResultHelper.Failed("密码错误",false));
            }
            //生成jwt令牌
            var token = _jwtTokenService.GenerateToken(loginDto.Email);
            var loginData = new LoginResponeseDto();
            loginData.Email = loginDto.Email;
            loginData.UserId=searchResult.UserId;
            loginData.Username=searchResult.Username;
            loginData.Token=token;
            return Ok(ResultHelper.Success(loginData,"登录成功"));
        }
        [HttpGet("userList")]
        [Authorize]
        public async Task<IActionResult> UserList(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery]string username = null,
            [FromQuery]string gender = null) 
        {
            var users=await _userRepository.GetAllUserAsync(pageNumber,pageSize,username,gender);
            return Ok(ResultHelper.Success(users) );
        }
        [HttpDelete("deleteUser")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromQuery]string userId)
        {
            if (! await _userRepository.DeleteUserByUserId(userId))
            {
                return Ok(ResultHelper.Failed("删除失败",false));
            }
            return Ok(ResultHelper.Success(true,"删除成功"));
        }

        [HttpPost("updateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            Console.WriteLine(updateUserDto);
            if(updateUserDto == null)
            {
                return Ok(ResultHelper.Failed("数据不完整",false));
            }
            User user = new User();
            user.Username = updateUserDto.Username;
            user.Gender = updateUserDto.Gender;
            user.UserId = updateUserDto.UserId;
            user.Phone=updateUserDto.Phone;
            user.UserRole = updateUserDto.UserRole;
            if(! await _userRepository.UpdateUserByUserIdAsync(user))
            {
                return Ok(ResultHelper.Failed("更新失败", false));
            }
            return Ok(ResultHelper.Success(true,"更新成功"));
        }
    }
}
