using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ENB.Students.Registration.Mvc.Queries
{
    public record GetAcademicYearsQuery:IQuery<IEnumerable<DisplayAcademicYear>>
    {
    }
}
