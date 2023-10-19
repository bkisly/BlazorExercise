using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorExercise.Services.User.SessionToken.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlazorExercise.Services.User.SessionToken
{
    public class SessionTokenGenerator : ISessionTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public SessionTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(IEnumerable<Claim> claims, TokenDescriptorConfigurationValues configurationValues)
        {
            var signingKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationValues.SecretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configurationValues.Issuer,
                Audience = configurationValues.Audience,
                Expires = DateTime.UtcNow.AddMinutes(configurationValues.ExpirationTimeMinutes),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
