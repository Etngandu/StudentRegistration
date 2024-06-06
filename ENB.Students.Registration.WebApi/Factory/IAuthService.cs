using ENB.Students.Registration.WebApi.Models;
using ENB.Students.Registration.WebApi.Models.AppUser;

namespace ENB.Students.Registration.WebApi.Factory
{
    public interface IAuthService
    {
        string GenerateTokenString(UserLoginModel userModel);
        Task<AuthenticatedResponse> Login(UserLoginModel userModel);
        Task<RegistrationResponse> Register(UserRegistrationModel userModel);
    }
}