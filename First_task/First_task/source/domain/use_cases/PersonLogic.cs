using First_task.source.data;
using First_task.source.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace First_task.source.domain.use_cases
{
    public class PersonLogic
    {
        private readonly IPersonRepository _repo;

        public PersonLogic(IPersonRepository repo)
        {
            _repo = repo;
        }

        public void DemonstrateEquals()
        {
            IEnumerable<Person> distinctPersons = _repo.Fetch().Distinct();
            for(int i =0;i <distinctPersons.Count() - 1; i++)
            {
                if(distinctPersons.ElementAt(i).Equals(distinctPersons.ElementAt(i+1)))
                {
                    throw new Exception("Methods Equals does not work correctly");
                }
            }
        }
        public string CountPerson()
        {
            int countStudents;
            int countTeachers;
            countStudents = _repo.Fetch().Where(p => p is Student).Count();
            countTeachers = _repo.Fetch().Where(p => p is Teacher).Count();
            string result;
            result = string.Format("Amount of student {0} and amount of teacher: {1}", countStudents, countTeachers);
            return result;
        }
    }
}
