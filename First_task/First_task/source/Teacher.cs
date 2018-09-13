using System;
using System.Collections.Generic;
using System.Linq;

namespace First_task.source
{
	class Teacher : Person
	{
		private string _degree;
		private string _subject;
		private List<string> _students;

		public string Degree
		{
			get => _degree;
			set => _degree = value;
		}

		public string Subject
		{
			get => _subject;
			set => _subject = value;
		}

		internal List<string> Students
		{
			get => _students;
			set => _students = value;
		}

		public Teacher()
		{
			Degree = string.Empty;
			Subject = string.Empty;
			Students = new List<string>();
		}

		public Teacher(string name, int age, string degree, string subject, List<string> students) : base(name, age)
		{
			Degree = degree;
			Subject = subject;
			foreach (string stud in students)
			{
				Students.Add(stud);
			}
		}

		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age}, Degree {Degree}, Subject: {Subject}" +
			       Students.Aggregate("", (current, student) => current + " " + student);
		}

		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nDegree: {0} \nSubject: {1}", Degree, Subject);
			foreach (var student in Students)
			{
				Console.WriteLine(student);
			}
		}

		public override void Input(string data)
		{
			base.Input(data);
			var words = data.Split(' ');
			Degree = words[2];
			Subject = words[3];
			for (int i = 4; i < words.Length; i++)
			{
				Students.Add(words[i]);
			}
		}

		public override bool Equals(object obj)
		{
			var teacher = obj as Teacher;
			return teacher != null &&
			       base.Equals(obj) &&
			       Degree == teacher.Degree &&
			       Subject == teacher.Subject &&
			       EqualityComparer<List<string>>.Default.Equals(Students, teacher.Students);
		}

		public override int GetHashCode()
		{
			var hashCode = 1332502943;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Degree);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Students);
			return hashCode;
		}

		public static bool operator ==(Teacher teacher1, Teacher teacher2)
		{
			return EqualityComparer<Teacher>.Default.Equals(teacher1, teacher2);
		}

		public static bool operator !=(Teacher teacher1, Teacher teacher2)
		{
			return !(teacher1 == teacher2);
		}
	}
}