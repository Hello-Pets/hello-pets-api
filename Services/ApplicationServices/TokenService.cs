using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using HelloPets.Data.Entities;
using HelloPets.Services.ApplicationServices.Interfaces;

namespace HelloPets.Services.ApplicationServices;

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Generate(User tutor, TimeSpan periodo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSection = _configuration.GetSection("JwtSettings");
            var secretKey = CheckJwtSettings(jwtSection, "SecretKey");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(tutor))/*Claims separado em um novo metodo*/,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.Add(periodo)
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

        private static IEnumerable<Claim> GetClaims(User tutor)
        {
            return
            [
                new Claim("id", tutor.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, tutor.Name),
                new Claim(JwtRegisteredClaimNames.Email, tutor.Email),

                //Insere a data de criacao do token ao token
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),

                //Cria um Id unico para o token dando maior seguranca
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
        }

        private string CheckJwtSettings(IConfigurationSection jwtSection, string key)
        {
            var value = jwtSection.GetValue<string>(key);
            ArgumentNullException.ThrowIfNull(value, $"{key} configuration is missing in JwtSettings.");

            return value;
        }

        public int GetUserIdFromToken()
        {
            string id = _httpContextAccessor?.HttpContext?.User?.FindFirstValue("id") ?? "";

            _ = int.TryParse(id, out int userId);

            return userId;
        }
    }