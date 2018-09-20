using System;
using System.Collections.Generic;
using System.Linq;
using First_task.source.domain.entities;
using First_task.source.domain.use_cases;

#pragma warning disable 1591

namespace First_task.source.presentation
{
	public class MainUi : IMainView
	{
		private readonly FetchPersons _fetchPersons;
		private readonly FetchUnigueListOfPersons _fetchUniqueListOfPersons;
		private readonly CountAmountOfPersons _countAmountOfPersons;

		private const string MENU_HELLO_MESSAGE = "\nHello! Press key to choose member.";
		private const string MENU_EXIT_MESSAGE = "Exit.";
		private const string MENU_SHOW_ALL_PERSONS_STRING = "Show all persons.";
		private const string MENU_SHOW_UNIQUE_PERSONS_STRING = "Show unique persons.";
		private const string MENU_SHOW_PERSONS_COUNT_STRING = "Show persons count.";

		private const ConsoleKey EXIT_KEY = ConsoleKey.Escape;
		private const ConsoleKey SHOW_ALL_PERSONS_KEY = ConsoleKey.Q;
		private const ConsoleKey SHOW_UNIQUE_PERSONS_KEY = ConsoleKey.W;
		private const ConsoleKey SHOW_PERSONS_COUNT_KEY = ConsoleKey.E;

		public MainUi(FetchPersons fetchPersons, FetchUnigueListOfPersons fetchUniqueListOfPersons,
			CountAmountOfPersons countAmountOfPersons)
		{
			_fetchUniqueListOfPersons = fetchUniqueListOfPersons;
			_fetchPersons = fetchPersons;
			_countAmountOfPersons = countAmountOfPersons;
		}

		public void ShowMenu()
		{
			HelloMessage();
			DrawMembers();
			HandleKeys();
		}

		private void ClearConsoleKeyInput()
		{
			while (Console.KeyAvailable)
			{
				Console.ReadKey(true);
			}
		}

		private void ShowAllPersons()
		{
			ShowPersons(_fetchPersons.Fetch());
		}

		private void ShowUniquePersons()
		{
			ShowPersons(_fetchUniqueListOfPersons.FetchUnique());
		}

		private void ShowPersons(List<Person> persons)
		{
			var teachers = persons.OfType<Teacher>().Select(person => person).ToList();
			var students = persons.OfType<Student>().Select(person => person).ToList();
			foreach (var teacher in teachers)
			{
				Console.WriteLine("\n\t" + teacher);
				foreach (var student in students)
				{
					if (student.TeacherId == teacher.Id)
					{
						Console.WriteLine("\t\t" + student);
					}
				}
			}
		}

		private void ShowPersonsCount()
		{
			Console.WriteLine("\n\tCount of persons:\n" + _countAmountOfPersons.CountPerson() + "\n");
		}

		private void HandleKeys()
		{
			do
			{
				ClearConsoleKeyInput();
				var pressedKey = Console.ReadKey(true);
				switch (pressedKey.Key)
				{
					case EXIT_KEY:
					{
						return;
					}
					case SHOW_ALL_PERSONS_KEY:
					{
						ShowAllPersons();
						DrawMembers();
						break;
					}
					case SHOW_UNIQUE_PERSONS_KEY:
					{
						ShowUniquePersons();
						DrawMembers();
						break;
					}
					case SHOW_PERSONS_COUNT_KEY:
					{
						ShowPersonsCount();
						DrawMembers();
						break;
					}
				}
			} while (true);
		}

		private void DrawMembers()
		{
			Console.WriteLine();
			Console.WriteLine("[" + EXIT_KEY + "]\t" + MENU_EXIT_MESSAGE);
			Console.WriteLine("[" + SHOW_ALL_PERSONS_KEY + "]\t" + MENU_SHOW_ALL_PERSONS_STRING);
			Console.WriteLine("[" + SHOW_UNIQUE_PERSONS_KEY + "]\t" + MENU_SHOW_UNIQUE_PERSONS_STRING);
			Console.WriteLine("[" + SHOW_PERSONS_COUNT_KEY + "]\t" + MENU_SHOW_PERSONS_COUNT_STRING);
			Console.WriteLine();
		}

		private void HelloMessage()
		{
			Console.WriteLine(MENU_HELLO_MESSAGE);
		}

		public void PrintError(string message)
		{
			Console.WriteLine(message);
		}
	}
}