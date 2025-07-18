using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Models
{
    //user实体
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
        public string Phone { get; set; } = string.Empty; 
        public string Gender { get; set; } = string.Empty;
        [Column("user_role")]
        public string UserRole { get;set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreateAt { get; set; }
    }
}
