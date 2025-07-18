using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        public string UserId { set; get; } = string.Empty;
        [Required]
        public string Username { set; get; } = string.Empty;
        [Required]
        public string Gender { set; get; } = string.Empty;
        [Required]
        public string Phone { set; get; } = string.Empty;
        [Required]
        public string UserRole { set; get; } = string.Empty;
    }
}
