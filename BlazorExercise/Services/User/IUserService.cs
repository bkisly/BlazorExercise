using BlazorExercise.Models.Dto;

namespace BlazorExercise.Services.User
{
    public interface IUserService
    {
        Task RegisterUser(UserCredentialsDto userCredentials);
        Task<string> SignIn(UserCredentialsDto credentials);
        void SignOut(object sessionToken);
    }
}
