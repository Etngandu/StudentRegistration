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
    public class StudentClassRegistrationConfiguration : IEntityTypeConfiguration<Student_Class_Registration>
    {
        public void Configure(EntityTypeBuilder<Student_Class_Registration> builder)
        {
            
            builder.Property(x => x.Other_details).HasMaxLength(350);

            builder.HasOne<Student>(cs => cs.Student)
                .WithMany(cf => cf.Student_Class_Registrations)
                .HasForeignKey(y => y.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<ClassR>(cs => cs.ClassR)
                .WithMany(cf => cf.Student_Class_Registrations)
                .HasForeignKey(y => y.ClassRId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<AcademicYear>(cs => cs.AcademicYear)
                .WithMany(cf => cf.Student_Class_Registrations)
                .HasForeignKey(y => y.AcademicYearId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
