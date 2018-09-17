using System;
using System.Collections.Generic;
using System.Linq;

namespace First_task.source
{
	class Teacher : Person
	{
		private string _degree;
		private string _subject;
		private List<string> _studentsId;

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

		internal List<string> StudentsId
		{
			get => _studentsId;
			set => _studentsId = value;
		}

		public Teacher()
		{
			Degree = string.Empty;
			Subject = string.Empty;
			StudentsId = new List<string>();
		}

		public Teacher(string name, int age,string id, string degree, string subject) : base(name, age,id)
		{
			Degree = degree;
			Subject = subject;			
		}

		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age}, Degree {Degree}, Subject: {Subject}" +
			       StudentsId.Aggregate("", (current, student) => current + " " + student);
		}

		public void AssignStudents(List<Student> students)
		{
			foreach (Student stud in students)
			{
				StudentsId.Add(stud.Id);
				stud.TeacherId = Id;
			}
		}
		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nDegree: {0} \nSubject: {1}", Degree, Subject);
			foreach (var student in StudentsId)
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
				StudentsId.Add(words[i]);
			}
		}

		public override bool Equals(object obj)
		{
			var teacher = obj as Teacher;
			return teacher != null &&
			       base.Equals(obj) &&
			       Degree == teacher.Degree &&
			       Subject == teacher.Subject &&
			       EqualityComparer<List<string>>.Default.Equals(StudentsId, teacher.StudentsId);
		}

		public override int GetHashCode()
		{
			var hashCode = 1332502943;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Degree);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(StudentsId);
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