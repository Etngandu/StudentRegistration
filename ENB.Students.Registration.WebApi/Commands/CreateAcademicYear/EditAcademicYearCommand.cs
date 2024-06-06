using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;

namespace ENB.Students.Registration.WebApi.Commands.CreateAcademicYear
{
    public record EditAcademicYearCommand(CreateAndEditAcademicYear createAndEditAcademicYear): ICommand<CreateAndEditAcademicYear>
    {
    }
}
