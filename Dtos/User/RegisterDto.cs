using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string Username { set; get; } = string.Empty;
        public string UserRole {  set; get; }= string.Empty;
        [Required]
        [EmailAddress]
        public string Email { set; get; } = string.Empty;
        public string password {  set; get; } = string.Empty;
        public string gender { set; get; } = string.Empty;
        public string phone { set; get; } = string.Empty;
    }
}
