using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ENB.Students.Registration.WebApi.Queries
{
    public record GetAcademicYearsQuery:IQuery<IEnumerable<DisplayAcademicYear>>
    {
    }
}
