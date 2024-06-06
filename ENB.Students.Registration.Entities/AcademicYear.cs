using ENB.Students.Registration.Entities.Collections;
using ENB.Students.Registration.Infrastucture;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities
{
    public class AcademicYear : DomainEntity<int>, IDateTracking
    {
        public AcademicYear()
        {
            Student_Class_Registrations = new();
            ClassRooms = new();
        }
        public string Ref_academicYear { get; set; } = string.Empty;
        public DateTime Start_AcademicYear { get; set; }
        public DateTime End_AcademicYear { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        //public string AcademicYear
        //{
        //    get
        //    {
        //        DateTime date = DateTime.Now;
        //        int curr = date.Year;
        //        if (date.Month <= 6) curr--;
        //        string ay = $"AY{curr}-{curr + 1}";

        //        return ay;
        //    }
        //    set { }
        //}

        public ClassRs ClassRooms { get; set; }
        public StudentsClassRegistrations Student_Class_Registrations { get; set; }

        public List<Error>? Errors => throw new NotImplementedException();

        public bool IsError => throw new NotImplementedException();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Start_AcademicYear > End_AcademicYear)
            {
                yield return new ValidationResult("Start_AcademicYear can't be greater then End_AcademicYear  ", new[] { "Start_AcademicYear", "End_AcademicYear" });
            }
        }
    }
}
