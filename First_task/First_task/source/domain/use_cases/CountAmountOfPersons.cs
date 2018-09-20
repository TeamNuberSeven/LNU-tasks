using First_task.source.data;
using First_task.source.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.source.domain.use_cases
{
    public class CountAmountOfPersons
    {
        private const string AMOUNT = "Amount of student ";
        private const string TEACHER_AMOUNT = "and amount of teacher: ";
        private readonly IPersonRepository _repo;

        public CountAmountOfPersons(IPersonRepository repo)
        {
            _repo = repo;
        }

        public string CountPerson()
        {
            int countStudents = _repo.Fetch().Where(p => p is Student).Count();
            int countTeachers = _repo.Fetch().Where(p => p is Teacher).Count();
            return string.Format(AMOUNT + countStudents + TEACHER_AMOUNT + countTeachers);
        }
    }
}
