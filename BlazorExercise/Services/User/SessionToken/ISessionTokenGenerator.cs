using System.Security.Claims;
using BlazorExercise.Services.User.SessionToken.Configuration;

namespace BlazorExercise.Services.User.SessionToken
{
    public interface ISessionTokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims, TokenDescriptorConfigurationValues configurationValues);
    }
}
