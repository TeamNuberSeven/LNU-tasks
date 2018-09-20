using First_task.source.data;
using First_task.source.domain.use_cases;
using First_task.source.presentation;
using System;

namespace First_task.source{
	class FirstProjectRoot{
		public static void Main(string[] args){
            var repo = new PersonRepository();
		    //var fetchPersons = new FetchPersons(repo);
		    //var ui = new MainUi(fetchPersons);
		    //fetchPersons.View = ui;
      //      ui.Print();
            var persons = new CheckForEquality(repo).DemonstrateEquals();
            persons.ForEach((person) =>
            {
                Console.WriteLine(person.ToString());
            });
		}
	}
}