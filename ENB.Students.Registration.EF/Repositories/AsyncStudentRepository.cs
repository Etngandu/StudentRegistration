using ENB.Students.Registration.Entities.Repositories;
using ENB.Students.Registration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace ENB.Students.Registration.EF.Repositories
{

    /// <summary>
    /// A concrete repository to work with case in the system.
    /// </summary>
    public class AsyncStudentRepository: AsyncRepository<Student, ErrorOr<Student>>, IAsyncStudentRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly StudentsRegistrationContext _studentsRegistrationContext  ;
        

        public AsyncStudentRepository(StudentsRegistrationContext studentsRegistrationContext):base(studentsRegistrationContext)
        {
            _studentsRegistrationContext = studentsRegistrationContext;
        }

        public IEnumerable<Student> FindByName(string lastname)
        {
            return _studentsRegistrationContext.Set<Student>().Where(x => x.LastName == lastname);
        }
    }
}
