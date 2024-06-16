using Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Data.JwtBearerConfiguration;
using System.Security.Claims;

namespace Data.Services
{
    public class TokenService
    {
        public static string Generate(Tutor tutor)
        {
            var key = Encoding.ASCII.GetBytes(PrivateKey.Key);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(tutor),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(12)
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            var tokenString = handler.WriteToken(token);

            return tokenString;
        }
        private static ClaimsIdentity GenerateClaims(Tutor tutor)
        {
            var claimIdentity = new ClaimsIdentity();
            claimIdentity.AddClaim(new Claim("tutor", tutor.Email));

            return claimIdentity;
        }
    }
}
