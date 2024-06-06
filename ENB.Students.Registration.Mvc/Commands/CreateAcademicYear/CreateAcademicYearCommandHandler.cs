using AutoMapper;
using AutoMapper.Execution;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Models;
using ENB.Students.Registration.Mvc.Queries;
using ErrorOr;

namespace ENB.Students.Registration.Mvc.Commands.CreateAcademicYear
{
    public class CreateAcademicYearCommandHandler : ICommandHandler<CreateAcademicYearCommand,ErrorOr<CreateAndEditAcademicYear>>
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

        
        public  async Task<ErrorOr<CreateAndEditAcademicYear>> Handle(CreateAcademicYearCommand request, CancellationToken cancellationToken)
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
