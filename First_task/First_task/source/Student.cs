using System;
using System.Collections.Generic;

namespace First_task.source
{
	class Student : Person
	{
		private string _facultet;
		private string _myTeacher;

		public string Facultet
		{
			get => _facultet;
			set => _facultet = value;
		}

		internal string MyTeacher
		{
			get => _myTeacher;
			set => _myTeacher = value;
		}

		public Student()
		{
			Facultet = string.Empty;
			MyTeacher = string.Empty;
		}

		public Student(string name, int age, string facultet, string teacher) : base(name, age)
		{
			Facultet = facultet;
			MyTeacher = teacher;
		}

		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age}, Facultet {Facultet}, My teacher: {MyTeacher}";
		}

		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nFacultet: {0} \n My teacher: {1}", Facultet, MyTeacher);
		}

		public override void Input(string data)
		{
			base.Input(data);
			var words = data.Split(' ');
			Facultet = words[2];
			MyTeacher = words[3];
		}

		public override bool Equals(object obj)
		{
			var student = obj as Student;
			return student != null &&
				   base.Equals(obj) &&
				   Facultet == student.Facultet &&
				   EqualityComparer<string>.Default.Equals(MyTeacher, student.MyTeacher);
		}

		public override int GetHashCode()
		{
			var hashCode = 1568470154;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Facultet);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MyTeacher);
			return hashCode;
		}

		public static bool operator ==(Student student1, Student student2)
		{
			return EqualityComparer<Student>.Default.Equals(student1, student2);
		}

		public static bool operator !=(Student student1, Student student2)
		{
			return !(student1 == student2);
		}
	}
}