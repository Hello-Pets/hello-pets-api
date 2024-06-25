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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(PrivateKey.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(tutor))/*Claims separado em um novo metodo*/,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(12)
            };

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating token", ex);
            }
        }
        private static IEnumerable<Claim> GetClaims(Tutor tutor)
        {
            return
            [
                new Claim("id", tutor.Id.ToString()),
                new Claim("nome", tutor.Name),
                new Claim("email", tutor.Email),
                //Insere a data de criacao do token ao token
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                //Cria um Id unico para o token dando maior seguranca
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
        }
    }
}
