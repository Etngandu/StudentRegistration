using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Models;

namespace ENB.Students.Registration.Mvc.Queries
{
    public record GetAcademicYearByIdQuery(int id):IQuery<DisplayAcademicYear>
    {
    }
}
