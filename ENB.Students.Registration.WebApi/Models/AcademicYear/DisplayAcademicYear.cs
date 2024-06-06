using ENB.Students.Registration.Entities.Collections;

namespace ENB.Students.Registration.WebApi.Models
{
    public class DisplayAcademicYear
    {
        public  int Id { get; set; }
        public string Ref_academicYear { get; set; } = string.Empty;
        public DateTime Start_AcademicYear { get; set; }
        public DateTime End_AcademicYear { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
       
    }
}
