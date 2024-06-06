using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Collections;
using ErrorOr;
using FluentValidation;

namespace ENB.Students.Registration.Mvc.Models
{
    public class CreateAndEditAcademicYear
    {
        public  int Id { get; set; }
        public string Ref_academicYear { get; set; } = string.Empty;
        public DateTime Start_AcademicYear { get; set; }
        public DateTime End_AcademicYear { get; set; }
       
    }

   

    
}
