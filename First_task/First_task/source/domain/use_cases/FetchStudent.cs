using System.Collections.Generic;
using First_task.source.data;
using First_task.source.domain.entities;

namespace First_task.source.domain.use_cases
{
	public class FetchStudent
	{
		private readonly IStudentRepository _repo;

		public FetchStudent(IStudentRepository repo)
		{
			_repo = repo;
		}

		public List<Student> Fetch()
		{
			return _repo.Fetch();
		}
	}
}