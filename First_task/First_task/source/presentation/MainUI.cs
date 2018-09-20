using System;
using First_task.source.domain.use_cases;

namespace First_task.source.presentation
{
	public class MainUi : IMainView
	{
		private readonly FetchPersons _fetchPersons;

		public MainUi(FetchPersons fetchPersons)
		{
		    _fetchPersons = fetchPersons;
		}

		public void Print()
		{
			var persons = _fetchPersons.Fetch();
			persons.ForEach((student) => { student.Print(); });
		}

	    public void PrintError(string message)
	    {
	        Console.WriteLine(message);
	    }
	}
}