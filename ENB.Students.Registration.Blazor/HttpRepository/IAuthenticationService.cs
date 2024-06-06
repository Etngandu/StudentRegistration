using ENB.Students.Registration.Blazor.DTO.AppUser;

namespace ENB.Students.Registration.Blazor.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> RegisterUser(UserRegistrationModel userRegistrationModel);
        Task<AuthenticatedResponse> Login(UserLoginModel userLoginModel);
        Task Logout();
    }
}
