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
    public class AsyncAcademicYeartRepository : AsyncRepository<AcademicYear,ErrorOr<AcademicYear>>, IAsyncAcademicYearRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly StudentsRegistrationContext _studentsRegistrationContext  ;
        

        public AsyncAcademicYeartRepository(StudentsRegistrationContext studentsRegistrationContext):base(studentsRegistrationContext)
        {
            _studentsRegistrationContext = studentsRegistrationContext;
        }

        public IEnumerable<AcademicYear> FindByRef(string refyear)
        {
            return _studentsRegistrationContext.Set<AcademicYear>().Where(x => x.Ref_academicYear == refyear);
        }

        
    }
}
