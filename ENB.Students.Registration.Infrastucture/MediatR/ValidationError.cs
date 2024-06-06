using System.Security.Cryptography.X509Certificates;

namespace ENB.Students.Registration.Infrastucture
{
    public class ValidationError
    {
        public string PropertyName;
        public string ErrorMessage;

        public ValidationError(string propertyName, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }
    }
}