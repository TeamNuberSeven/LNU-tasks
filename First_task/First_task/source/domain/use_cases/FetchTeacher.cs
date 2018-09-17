using System.Collections.Generic;
using First_task.source.data;
using First_task.source.domain.entities;

namespace First_task.source.domain.use_cases
{
	public class FetchTeacher
	{
		private readonly ITeacherRepository _repo;

		public FetchTeacher(ITeacherRepository repo)
		{
			_repo = repo;
		}

		public List<Teacher> Fetch()
		{
			return _repo.Fetch();
		}

	}
}