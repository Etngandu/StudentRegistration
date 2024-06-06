using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ApplicationException = ENB.Students.Registration.Infrastucture.ModelValidationException;

namespace ENB.Students.Registration.Infrastucture
{
    public sealed class ValidationExceptionMvc : ModelValidationException
    {
        public ValidationExceptionMvc(IEnumerable<ValidationError> validationErrors)
            : base("Validation Failure")
            => ValidationErrors = validationErrors;

        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
