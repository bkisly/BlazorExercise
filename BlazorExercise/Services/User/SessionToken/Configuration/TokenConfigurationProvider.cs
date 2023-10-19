namespace BlazorExercise.Services.User.SessionToken.Configuration
{
    public class TokenConfigurationProvider : ITokenConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public TokenConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDescriptorConfigurationValues GetConfiguration()
        {
            return new TokenDescriptorConfigurationValues(
                _configuration.GetValue<string>("JwtConfiguration:Issuer") ?? "default",
                _configuration.GetValue<string>("JwtConfiguration:Audience") ?? "default",
                _configuration.GetValue<int>("JwtConfiguration:ExpirationTimeMinutes"),
                _configuration.GetValue<string>("JwtConfiguration:SecretKey") ?? "default"
            );
        }
    }
}
