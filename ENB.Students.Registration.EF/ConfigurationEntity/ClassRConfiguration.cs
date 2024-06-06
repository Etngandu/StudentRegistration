using ENB.Students.Registration.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Church.Members.EF.ConfigurationEntity
{
    public class ClassRConfiguration : IEntityTypeConfiguration<ClassR>
    {
        public void Configure(EntityTypeBuilder<ClassR> builder)
        {

            builder.Property(x => x.ClassName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ClassDescription).HasMaxLength(350);           
            builder.Property(x => x.Other_details).HasMaxLength(450);

            builder.HasOne<AcademicYear>(cs => cs.AcademicYear)
                .WithMany(cf => cf.ClassRooms)
                .HasForeignKey(y => y.AcademicYearId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
