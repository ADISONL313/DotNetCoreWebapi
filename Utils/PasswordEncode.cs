using BCrypt.Net;

namespace UserManager.Utils
{
    public static class PasswordEncode
    {
        public static string HashEncode(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool VerifyPassword(string password_1, string password_2) {
            return BCrypt.Net.BCrypt.Verify(password_1,password_2);
        }
    }
}
