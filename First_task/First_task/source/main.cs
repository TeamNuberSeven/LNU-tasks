using First_task.source.data;
using First_task.source.domain.use_cases;
using First_task.source.presentation;

namespace First_task.source{
	class FirstProjectRoot{
		public static void Main(string[] args){
		    var fetchPersons = new FetchPersons(new PersonRepository());
		    var ui = new MainUi(fetchPersons);
		    fetchPersons.View = ui;
            ui.Print();
		}
	}
}