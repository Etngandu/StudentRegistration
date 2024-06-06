using ENB.Students.Registration.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Entities.Repositories
{
    /// <summary>
    /// Defines the various methods available to work with people in the system.
    /// </summary>
    public interface IAsyncParentsGuardiansRepository: IAsyncRepository<Parents_and_Guardian, int>
    {
        /// <summary>
        /// Gets a list of all the people whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Physician with the matching Physician name.</returns>

        IEnumerable<Parents_and_Guardian> FindByName(string name);
    }
}
