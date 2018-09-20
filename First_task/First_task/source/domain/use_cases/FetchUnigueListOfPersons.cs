using First_task.source.data;
using First_task.source.domain.entities;
using System.Collections.Generic;
using System.Linq;

namespace First_task.source.domain.use_cases
{
	/// <summary>
	/// Use case to fetch unique base data in format <see cref="Person"/>/<see cref="Teacher"/>/<see cref="Student"/>.
	/// </summary>
	public class FetchUnigueListOfPersons
    {
        private readonly IPersonRepository _repo;

		/// <summary>
		/// Initialise new instance of <see cref="FetchUnigueListOfPersons"/> class, which have declared repository.
		/// </summary>
		/// <param name="repo"></param>
		public FetchUnigueListOfPersons(IPersonRepository repo)
        {
            _repo = repo;
        }

		/// <summary>
		/// Fetch data from repository.
		/// </summary>
		/// <returns></returns>
		public List<Person> FetchUnique()
        {
            IEnumerable<Person> persons = _repo.Fetch().Distinct();
            return persons.ToList();            
        }
    }
}
