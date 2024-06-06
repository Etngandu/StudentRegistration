using ENB.Students.Registration.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities
{
    public class Student_Class_Registration : DomainEntity<int>, IDateTracking
    {
        public int? ClassRId { get; set; }
        public ClassR? ClassR  { get; set; }
        public  int? StudentId { get; set; }
        public Student? Student  { get; set; }
        public AcademicYear? AcademicYear { get; set; }
        public int? AcademicYearId { get; set; }
        public DateTime Date_of_first_Class { get; set; }
        public DateTime Date_of_last_Class { get; set; }
        public string Other_details { get; set; } = string.Empty;
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModified { get ; set ; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
