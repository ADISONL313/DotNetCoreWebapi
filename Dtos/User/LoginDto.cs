using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos.User
{
    public class LoginDto
    {
        [Required]
        public string Email { set; get; }=string.Empty;
        [Required]
        public string Password { set; get; } = string.Empty;
    }
    public class LoginResponeseDto
    {
        public string Token { set; get; } = string.Empty;
        public string UserId { set; get; } = string.Empty;
        public string Username { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
    }
}
