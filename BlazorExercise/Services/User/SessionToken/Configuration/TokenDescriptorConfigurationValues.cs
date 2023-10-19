namespace BlazorExercise.Services.User.SessionToken.Configuration;

public record TokenDescriptorConfigurationValues(
    string Issuer,
    string Audience,
    int ExpirationTimeMinutes,
    string SecretKey);
