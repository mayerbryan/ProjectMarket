using Microsoft.IdentityModel.Tokens;
using ProjectMarket.Application.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectMarket.Api.Services
{
    public class TokenService
    {
        public string GenerateToken(UserModel User) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var tokenDescryptor = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity (new Claim[]{ 
                    new Claim(ClaimTypes.Name, "Mayer"),
                    new Claim(ClaimTypes.Role, "Admin")
                }),

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescryptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
