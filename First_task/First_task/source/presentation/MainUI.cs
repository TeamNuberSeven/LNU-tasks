using System;
using First_task.source.domain.use_cases;

namespace First_task.source.presentation
{
	public class MainUi : IMainView
	{
		private readonly FetchPersons _fetchPersons;
        private readonly FetchUnigueListOfPersons _fetchUniqueListOfPersons;

        public MainUi(FetchPersons fetchPersons, FetchUnigueListOfPersons fetchUniqueListOfPersons)
		{
            _fetchUniqueListOfPersons = fetchUniqueListOfPersons;
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