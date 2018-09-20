using First_task.source.data;
using First_task.source.domain.use_cases;
using First_task.source.presentation;

namespace First_task.source{
	class FirstProjectRoot{
		public static void Main(string[] args){
            var repo = new PersonRepository();
            var fetchPersons = new FetchPersons(repo);
			var fetchUniqueListOfPersons = new FetchUnigueListOfPersons(repo);
			var countAmountOfPersons = new CountAmountOfPersons(repo);
			var ui = new MainUi(fetchPersons, fetchUniqueListOfPersons, countAmountOfPersons);
			fetchPersons.View = ui;
			ui.ShowMenu();
		}
	}
}