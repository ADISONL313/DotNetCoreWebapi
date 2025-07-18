using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserManager.Utils
{
    public class JwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
        public string GenerateToken(string email,IEnumerable<Claim> extraClaims = null)
        {
            var claims = new List<Claim>();
            {
                new Claim(ClaimTypes.Name, email);
            }
            if (extraClaims != null)
            {
                claims.AddRange(extraClaims);
            }
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token=new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                claims:claims,
                expires:DateTime.Now.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }
    }
}
