using System.Collections.Generic;
using First_task.source.domain.entities;

namespace First_task.source.data
{
	public class StudentRepository : IStudentRepository
	{
		public List<Student> Fetch()
		{
			return new List<Student>
			{
				new Student("Vitalik", 19, "1", "Applied math", "1"),
				new Student("Oleksii", 19, "2", "Applied math", "2"),
				new Student("Luibomur", 21, "3", "Applied math", "1")
			};
		}
	}
}