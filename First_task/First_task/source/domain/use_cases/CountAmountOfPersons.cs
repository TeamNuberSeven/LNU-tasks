using First_task.source.data;
using First_task.source.domain.entities;
using System.Linq;

namespace First_task.source.domain.use_cases
{
	/// <summary>
	/// Gives you class for counting <see cref="Person"/> in collection.
	/// </summary>
	public class CountAmountOfPersons
    {
        private const string AMOUNT = "Amount of student ";
        private const string TEACHER_AMOUNT = "\nAmount of teacher: ";
        private readonly IPersonRepository _repo;

		/// <summary>
		/// Initialise new instance of <see cref="CountAmountOfPersons"/> class, which have declared repository.
		/// </summary>
		/// <param name="repo"></param>
		public CountAmountOfPersons(IPersonRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Counts <see cref="Person"/> and gives you <see cref="string"/> with number.
        /// </summary>
        /// <returns></returns>
        public string CountPerson()
        {
            int countStudents = _repo.Fetch().Where(p => p is Student).Count();
            int countTeachers = _repo.Fetch().Where(p => p is Teacher).Count();
            return string.Format(AMOUNT + countStudents + TEACHER_AMOUNT + countTeachers);
        }
    }
}
