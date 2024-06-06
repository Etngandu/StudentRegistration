using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Models;
using ErrorOr;
using FluentValidation;

namespace ENB.Students.Registration.Mvc.Commands.CreateAcademicYear
{
    public record CreateAcademicYearCommand(CreateAndEditAcademicYear createAndEditAcademicYear): ICommand<ErrorOr<CreateAndEditAcademicYear>>
    { }


    public sealed class CreateAcademicYearCommandValidator:AbstractValidator<CreateAcademicYearCommand>

    {
        public CreateAcademicYearCommandValidator()
        {
            RuleFor(x => x.createAndEditAcademicYear.Ref_academicYear)
            .NotEmpty()
            .WithMessage("Ref_academicYear  can't be empty");


            RuleFor(x => x.createAndEditAcademicYear.Start_AcademicYear)            
           .LessThan(x => x.createAndEditAcademicYear.End_AcademicYear)
           .WithMessage($"Start_AcademicYear should be less than End_AcademicYear ");
        }

    }

}
