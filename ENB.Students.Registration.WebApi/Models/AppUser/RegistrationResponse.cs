namespace ENB.Students.Registration.WebApi.Models.AppUser
{
    public class RegistrationResponse
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
