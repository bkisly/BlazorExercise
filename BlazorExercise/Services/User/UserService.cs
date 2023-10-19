using System.Security.Claims;
using BlazorExercise.Models.Dto;
using BlazorExercise.Services.User.SessionToken;
using BlazorExercise.Services.User.SessionToken.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlazorExercise.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISessionTokenGenerator _tokenGenerator;
        private readonly ITokenConfigurationProvider _tokenConfigurationProvider;

        public UserService(UserManager<IdentityUser> userManager, ISessionTokenGenerator tokenGenerator, ITokenConfigurationProvider tokenConfigurationProvider)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _tokenConfigurationProvider = tokenConfigurationProvider;
        }

        public async Task RegisterUser(UserCredentialsDto userCredentials)
        {
            var registrationResult = await _userManager.CreateAsync(
                new IdentityUser { UserName = userCredentials.Name },
                userCredentials.Password);

            if (!registrationResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to create a user, please review your credentials.");
            }
        }

        public async Task<string> SignIn(UserCredentialsDto credentials)
        {
            var user = await ValidateUser(credentials);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, credentials.Name),
                new Claim("UserId", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return _tokenGenerator.GenerateToken(claims, _tokenConfigurationProvider.GetConfiguration());
        }

        public void SignOut(object sessionToken)
        {
            
        }

        private async Task<IdentityUser> ValidateUser(UserCredentialsDto userCredentials)
        {
            var user = await _userManager.FindByNameAsync(userCredentials.Name);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userCredentials.Password))
            {
                throw new InvalidOperationException("Invalid username or password.");
            }

            return user;
        }
    }
}
