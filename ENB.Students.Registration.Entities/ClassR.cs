using ENB.Students.Registration.Entities.Collections;
using ENB.Students.Registration.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities
{
    public class ClassR : DomainEntity<int>, IDateTracking
    {
        public ClassR()
        {
            Student_Class_Registrations = new();
        }

        public string ClassName { get; set; } = string.Empty;
        public string ClassDescription { get; set; } = string.Empty;
        public string Other_details { get; set; } = string.Empty;
        public AcademicYear? AcademicYear  { get; set; }
        public int AcademicYearId { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModified { get ; set ; }

        public StudentsClassRegistrations Student_Class_Registrations { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
