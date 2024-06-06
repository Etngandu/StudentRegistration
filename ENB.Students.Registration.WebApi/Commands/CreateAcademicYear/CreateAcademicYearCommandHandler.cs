using AutoMapper;
using AutoMapper.Execution;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;
using ENB.Students.Registration.WebApi.Queries;

namespace ENB.Students.Registration.WebApi.Commands.CreateAcademicYear
{
    public class CreateAcademicYearCommandHandler : ICommandHandler<CreateAcademicYearCommand, CreateAndEditAcademicYear>
    {
        private readonly IAsyncAcademicYearRepository _asyncAcademicYearRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAcademicYearCommandHandler> _logger;

        public CreateAcademicYearCommandHandler(IAsyncAcademicYearRepository asyncAcademicYearRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, IMapper mapper, ILogger<CreateAcademicYearCommandHandler> logger)
        {
            _asyncAcademicYearRepository = asyncAcademicYearRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _mapper = mapper;
            _logger = logger;
        }

        
        public  async Task<CreateAndEditAcademicYear> Handle(CreateAcademicYearCommand request, CancellationToken cancellationToken)
        {
            await using (await _asyncUnitOfWorkFactory.Create())
            {
               
                AcademicYear dbacademicYear = new();
                _mapper.Map(request.createAndEditAcademicYear, dbacademicYear);

                await _asyncAcademicYearRepository.Add(dbacademicYear, cancellationToken);

                //  _notyf.Success("Member Created  Successfully! ");

                return request.createAndEditAcademicYear;
            }
        }
    }
}
