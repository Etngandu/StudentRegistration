﻿// <auto-generated />
using System;
using ENB.Students.Registration.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENB.Students.Registration.EF.Migrations
{
    [DbContext(typeof(StudentsRegistrationContext))]
    partial class StudentsRegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENB.Students.Registration.Entities.AcademicYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End_AcademicYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ref_academicYear")
                        .IsRequired()
                        .HasMaxLength(215)
                        .HasColumnType("nvarchar(215)");

                    b.Property<DateTime>("Start_AcademicYear")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AcademicYear");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.ClassR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<string>("ClassDescription")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AcademicYearId");

                    b.ToTable("ClassR");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Parents_and_Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Parents_and_Guardian");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_first_rental")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_left_university")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Student", t =>
                        {
                            t.Property("Other_details")
                                .HasColumnName("Student_Other_details");
                        });
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student_Class_Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassRId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_of_first_Class")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_of_last_Class")
                        .HasColumnType("datetime2");

                    b.Property<string>("Other_details")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademicYearId");

                    b.HasIndex("ClassRId");

                    b.HasIndex("StudentId");

                    b.ToTable("Student_Class_Registration");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student_Relatioship", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("Parents_And_GuardianId")
                        .HasColumnType("int");

                    b.Property<int>("Ref_Relationship_Type")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "Parents_And_GuardianId");

                    b.HasIndex("Parents_And_GuardianId");

                    b.ToTable("Student_Relatioship");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "94a695e7-dac4-4110-aa8c-248892b6c346",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "70145bc5-2e94-41a0-8981-9211ddf24368",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "63620614-7db2-4501-adac-a4226a3640c9",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "5281a934-f9f7-4bd6-99b2-a2f64551dbe7",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.ClassR", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.AcademicYear", "AcademicYear")
                        .WithMany("ClassRooms")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Parents_and_Guardian", b =>
                {
                    b.OwnsOne("ENB.Students.Registration.Entities.Address", "AddressParentGuardian", b1 =>
                        {
                            b1.Property<int>("Parents_and_GuardianId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("Parents_and_GuardianId");

                            b1.ToTable("Parents_and_Guardian");

                            b1.WithOwner()
                                .HasForeignKey("Parents_and_GuardianId");
                        });

                    b.Navigation("AddressParentGuardian")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student", b =>
                {
                    b.OwnsOne("ENB.Students.Registration.Entities.Address", "StudentHomeAddress", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.OwnsOne("ENB.Students.Registration.Entities.Student_Address", "StudentLocalAddress", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Country");

                            b1.Property<DateTime>("Date_first_rental")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Date_left_university")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Number_street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(600)
                                .HasColumnType("nvarchar(600)")
                                .HasDefaultValue("")
                                .HasColumnName("Numberstreet");

                            b1.Property<string>("Other_details")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("Other_details");

                            b1.Property<string>("State_province_county")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasDefaultValue("")
                                .HasColumnName("State_province_county");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasDefaultValue("")
                                .HasColumnName("ZipCode");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("StudentHomeAddress")
                        .IsRequired();

                    b.Navigation("StudentLocalAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student_Class_Registration", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.AcademicYear", "AcademicYear")
                        .WithMany("Student_Class_Registrations")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ENB.Students.Registration.Entities.ClassR", "ClassR")
                        .WithMany("Student_Class_Registrations")
                        .HasForeignKey("ClassRId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ENB.Students.Registration.Entities.Student", "Student")
                        .WithMany("Student_Class_Registrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AcademicYear");

                    b.Navigation("ClassR");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student_Relatioship", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.Parents_and_Guardian", "Parents_And_Guardian")
                        .WithMany()
                        .HasForeignKey("Parents_And_GuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.Students.Registration.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parents_And_Guardian");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENB.Students.Registration.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ENB.Students.Registration.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.AcademicYear", b =>
                {
                    b.Navigation("ClassRooms");

                    b.Navigation("Student_Class_Registrations");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.ClassR", b =>
                {
                    b.Navigation("Student_Class_Registrations");
                });

            modelBuilder.Entity("ENB.Students.Registration.Entities.Student", b =>
                {
                    b.Navigation("Student_Class_Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
