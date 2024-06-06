using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;

namespace ENB.Students.Registration.WebApi.Queries
{
    public record GetAcademicYearByIdQuery(int id):IQuery<DisplayAcademicYear>
    {
    }
}
