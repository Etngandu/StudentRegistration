namespace ENB.Students.Registration.WebApi.Models.AppUser
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
