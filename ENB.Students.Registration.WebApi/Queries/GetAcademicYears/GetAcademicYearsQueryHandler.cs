using AutoMapper;
using AutoMapper.Execution;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ENB.Students.Registration.WebApi.Queries.GetAcademicYears
{
    public class GetAcademicYearsQueryHandler : IQueryHandler<GetAcademicYearsQuery, IEnumerable<DisplayAcademicYear>>
    {
        private readonly IAsyncAcademicYearRepository _asyncAcademicYearRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAcademicYearByIdHandler> _logger;

        public GetAcademicYearsQueryHandler(IAsyncAcademicYearRepository asyncAcademicYearRepository, IMapper mapper, ILogger<GetAcademicYearByIdHandler> logger , IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory)
        {
            _asyncAcademicYearRepository = asyncAcademicYearRepository;
            _mapper = mapper;
            _logger = logger;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
        }

        

        //public async Task<JsonResult> Handle(GetAcademicYearsQuery request, CancellationToken cancellationToken)
        //{
        //    IQueryable<AcademicYear> academicyears = _asyncAcademicYearRepository.FindAll();

        //    var Mpdata = _mapper.Map<List<DisplayAcademicYear>>(academicyears).ToList();
        //    await Task.FromResult(Mpdata);

        //    return Json(new { data = Mpdata });

        
        //}
        public async Task<IEnumerable<DisplayAcademicYear>> Handle(GetAcademicYearsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<AcademicYear> academicyears = _asyncAcademicYearRepository.FindAll();

            var Mpdata = _mapper.Map<List<DisplayAcademicYear>>(academicyears).ToList();
             
            await Task.FromResult(Mpdata);          

            return  Mpdata;
        }

        //public async Task<JsonResult> IRequestHandler<GetAcademicYearsQuery, JsonResult>.Handle(GetAcademicYearsQuery request, CancellationToken cancellationToken)
        //{
        //    IQueryable<AcademicYear> academicyears = _asyncAcademicYearRepository.FindAll();

        //    var Mpdata = _mapper.Map<List<DisplayAcademicYear>>(academicyears).ToList();
        //    await Task.FromResult(Mpdata);

        //    return Json(new { data = Mpdata }); ;
        //}
    }
}
