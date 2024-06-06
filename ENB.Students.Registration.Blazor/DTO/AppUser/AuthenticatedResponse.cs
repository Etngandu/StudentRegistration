namespace ENB.Students.Registration.Blazor.DTO.AppUser
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
