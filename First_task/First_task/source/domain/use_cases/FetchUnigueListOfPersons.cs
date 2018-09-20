using First_task.source.data;
using First_task.source.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.source.domain.use_cases
{
    class FetchUnigueListOfPersons
    {
        private readonly IPersonRepository _repo;

        public FetchUnigueListOfPersons(IPersonRepository repo)
        {
            _repo = repo;
        }

        public List<Person> FetchUnique()
        {
            IEnumerable<Person> persons = _repo.Fetch().Distinct();
            return persons.ToList();            
        }
    }
}
