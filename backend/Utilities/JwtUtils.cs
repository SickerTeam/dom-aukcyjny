using backend.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Utilities
{
    public class JwtUtils
    {
        private readonly IConfiguration _configuration;

        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(DbUser user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user), "User cannot be null");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration["SecretKey"];
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            }),
                Issuer = _configuration["ValidIssuer"],
                Audience = _configuration["ValidAudiences"],
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["ExpirationInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}