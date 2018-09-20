using System;
using System.Collections.Generic;

namespace First_task.source.domain.entities
{
	public class Student : Person
	{
		private string _facility;
		private string _teacherId;

		public string Facility
		{
			get => _facility;
			set => _facility = value;
		}

		internal string TeacherId
		{
			get => _teacherId;
			set => _teacherId = value;
		}

		public Student()
		{
			Facility = string.Empty;
			TeacherId = string.Empty;
		}

		public Student(string name, int age, string id, string facility, string teacherId) : base(name, age,id)
		{
			Facility = facility;
			TeacherId = teacherId;
		}

		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age}, Facility {Facility}";
		}

		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nFacility: {Facility}");
		}

		public override void Input(string data)
		{
			base.Input(data);
			var words = data.Split(' ');
			Facility = words[2];
			TeacherId = words[3];
		}

		public override bool Equals(object obj)
		{
			var student = obj as Student;
			return student != null &&
			       base.Equals(obj) &&
			       Facility == student.Facility &&
			       EqualityComparer<string>.Default.Equals(TeacherId, student.TeacherId);
		}

		public override int GetHashCode()
		{
			var hashCode = 1568470154;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Facility);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TeacherId);
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