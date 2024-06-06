using ENB.Students.Registration.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.EF.ConfigurationEntity
{
    public class StudentRelatioshipConfiguration : IEntityTypeConfiguration<Student_Relatioship>
    {
        public void Configure(EntityTypeBuilder<Student_Relatioship> builder)
        {

            builder.HasKey(x => new { x.StudentId, x.Parents_And_GuardianId });

        }
    }
}
