using AutoMapper;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Models;

namespace ENB.Students.Registration.WebApi.Commands.CreateAcademicYear
{
    public class EditAcademicYearCommandHandler : ICommandHandler<EditAcademicYearCommand, CreateAndEditAcademicYear>
    {

        private readonly IAsyncAcademicYearRepository _asyncAcademicYearRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<EditAcademicYearCommandHandler> _logger;

        public EditAcademicYearCommandHandler(IAsyncAcademicYearRepository asyncAcademicYearRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, IMapper mapper, ILogger<EditAcademicYearCommandHandler> logger)
        {
            _asyncAcademicYearRepository = asyncAcademicYearRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateAndEditAcademicYear> Handle(EditAcademicYearCommand request, CancellationToken cancellationToken)
        {
            await using (await _asyncUnitOfWorkFactory.Create())
            {

                AcademicYear dbacademicYearToUpdate = await _asyncAcademicYearRepository.FindById(request.createAndEditAcademicYear.Id);

                _mapper.Map(request.createAndEditAcademicYear, dbacademicYearToUpdate, typeof(CreateAndEditAcademicYear), typeof(AcademicYear));
              

                //  _notyf.Success("Member Created  Successfully! ");

                return request.createAndEditAcademicYear;
            }
        }
    }
}
