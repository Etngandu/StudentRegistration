﻿using ENB.Students.Registration.Entities;
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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Other_details).IsRequired().HasMaxLength(250);
            builder.OwnsOne(o => o.StudentHomeAddress, a =>
            {
                a.Property(p => p.Number_street).HasMaxLength(600)
                    .HasColumnName("Numberstreet")
                    .HasDefaultValue("");
                a.Property(p => p.City).HasMaxLength(250)
                    .HasColumnName("City")
                    .HasDefaultValue("");
                a.Property(p => p.State_province_county).HasMaxLength(250)
                    .HasColumnName("State_province_county")
                    .HasDefaultValue("");
                a.Property(p => p.Zipcode).HasMaxLength(12)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");
                a.Property(p => p.Country).HasMaxLength(250)
                   .HasColumnName("Country")
                   .HasDefaultValue("");
            });
            builder.OwnsOne(o => o.StudentLocalAddress, a =>
            {
                a.Property(p => p.Number_street).HasMaxLength(600)
                    .HasColumnName("Numberstreet")
                    .HasDefaultValue("");
                a.Property(p => p.City).HasMaxLength(250)
                    .HasColumnName("City")
                    .HasDefaultValue("");
                a.Property(p => p.State_province_county).HasMaxLength(250)
                    .HasColumnName("State_province_county")
                    .HasDefaultValue("");
                a.Property(p => p.Zipcode).HasMaxLength(12)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");
                a.Property(p => p.Country).HasMaxLength(250)
                   .HasColumnName("Country")
                   .HasDefaultValue("");
                a.Property(p => p.Other_details).HasMaxLength(250)
                   .HasColumnName("Other_details")
                   .HasDefaultValue("");

            });

        }
    }
}
