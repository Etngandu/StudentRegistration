using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities
{
    public class Student_Relatioship
    {
        public int StudentId { get; set; }
        public Student?  Student { get; set; }
        public int? Parents_And_GuardianId { get; set; }
        public Parents_and_Guardian?  Parents_And_Guardian { get; set; }
        public Ref_relationship_type  Ref_Relationship_Type { get; set; }
    }
}
