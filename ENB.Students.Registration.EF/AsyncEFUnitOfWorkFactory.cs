using ENB.Students.Registration.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace ENB.Students.Registration.EF
{
  public  class AsyncEFUnitOfWorkFactory :IAsyncUnitOfWorkFactory
    {
        private readonly StudentsRegistrationContext  _studentsRegistrationContext;
      

        public AsyncEFUnitOfWorkFactory(StudentsRegistrationContext    studentsRegistrationContext)
        {
            _studentsRegistrationContext = studentsRegistrationContext;

        }
        public AsyncEFUnitOfWorkFactory(bool forcenew, StudentsRegistrationContext   studentsRegistrationContext)
        {
                _studentsRegistrationContext = studentsRegistrationContext;

        }
        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        public async Task<IAsyncUnitOfWork> Create()
        {
            return await Create(false);
        }

        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing data context from the storage container.</param>
        public async Task<IAsyncUnitOfWork> Create(bool forceNew)
        {
            var asyncEFUnitOfWork = await Task.FromResult(new AsyncEFUnitOfWork(forceNew,_studentsRegistrationContext));

            return asyncEFUnitOfWork!;

        }


    }
}
