namespace BlazorExercise.Services.User.SessionToken.Configuration
{
    public interface ITokenConfigurationProvider
    {
        TokenDescriptorConfigurationValues GetConfiguration();
    }
}
