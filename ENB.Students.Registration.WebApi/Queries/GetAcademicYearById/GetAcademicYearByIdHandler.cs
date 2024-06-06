using AutoMapper;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;

namespace ENB.Students.Registration.WebApi.Queries
{
    public class GetAcademicYearByIdHandler : IQueryHandler<GetAcademicYearByIdQuery, DisplayAcademicYear>
    {
        private readonly IAsyncAcademicYearRepository _asyncAcademicYearRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAcademicYearByIdHandler> _logger ;



        public GetAcademicYearByIdHandler(IAsyncAcademicYearRepository asyncAcademicYearRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, IMapper mapper, ILogger<GetAcademicYearByIdHandler> logger = null)
        {
            _asyncAcademicYearRepository = asyncAcademicYearRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<DisplayAcademicYear> Handle(GetAcademicYearByIdQuery request, CancellationToken cancellationToken)
        {
            var academinyear = await _asyncAcademicYearRepository.FindById(request.id);
            var data = _mapper.Map<DisplayAcademicYear>(academinyear);
           // _logger.LogInformation("{data}",data);
            return data;
        }
    }
}
