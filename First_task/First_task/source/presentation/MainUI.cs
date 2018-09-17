using First_task.source.domain.use_cases;

namespace First_task.source.presentation
{
	public class MainUi
	{
		private readonly FetchStudent _fetchStudent;
		private readonly FetchTeacher _fetchTeacher;

		public MainUi(FetchStudent fetchStudent, FetchTeacher fetchTeacher)
		{
			_fetchStudent = fetchStudent;
			_fetchTeacher = fetchTeacher;
		}

		public void Print()
		{
			var students = _fetchStudent.Fetch();
			students.ForEach((student) => { student.Print(); });
		}
	}
}