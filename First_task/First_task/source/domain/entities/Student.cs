using System;
using System.Collections.Generic;

namespace First_task.source.domain.entities
{
	/// <summary>
	/// Implementation of <see cref="Person"/>.
	/// </summary>
	public class Student : Person
	{
		private string _facility;
		private string _teacherId;

		/// <summary>
		/// Get/Set of <see cref="Student"/> facility.
		/// </summary>
		public string Facility
		{
			get => _facility;
			set => _facility = value;
		}

		/// <summary>
		/// Get/Set of <see cref="Student"/> -> <see cref="Teacher"/>Id.
		/// </summary>
		public string TeacherId
		{
			get => _teacherId;
			set => _teacherId = value;
		}


		/// <summary>
		/// Initialise new instance of <see cref="Student"/> class, which have default values.
		/// </summary>
		public Student()
		{
			Facility = string.Empty;
			TeacherId = string.Empty;
		}

		/// <summary>
		/// Initialise new instance of <see cref="Student"/> class, which have declared values.
		/// </summary>
		/// <param name="name"><see cref="Student"/> name.</param>
		/// <param name="age"><see cref="Student"/> age.</param>
		/// <param name="id"><see cref="Student"/> id.</param>
		/// <param name="facility"><see cref="Student"/> facility.</param>
		/// <param name="teacherId"><see cref="Teacher"/> ID.</param>
		public Student(string name, int age, string id, string facility, string teacherId) : base(name, age,
			id)
		{
			Facility = facility;
			TeacherId = teacherId;
		}

		/// <summary>
		/// Converts <see cref="Student"/> value of this instance into string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"Name: {Name}, Age: {Age}, Facility {Facility}";
		}

		/// <summary>
		/// Prints this instance into <see cref="Console"/>.
		/// </summary>
		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nFacility: {Facility}");
		}

		/// <summary>
		/// Converts <see cref="data"/> into into instance of <see cref="Student"/> and sets this instance like that.
		/// </summary>
		/// <param name="data"><see cref="string"/> of data, compatible to this instance.</param>
		public override void Input(string data)
		{
			base.Input(data);
			var words = data.Split(' ');
			Facility = words[2];
			TeacherId = words[3];
		}

		/// <summary>
		/// Gives value, which shows if this instance is equal to passed.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			var student = obj as Student;
			return student != null &&
			       base.Equals(obj) &&
			       Facility == student.Facility &&
			       EqualityComparer<string>.Default.Equals(TeacherId, student.TeacherId);
		}

		/// <summary>
		/// Gives hash code of this instance.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = 1568470154;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Facility);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TeacherId);
			return hashCode;
		}

		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="student1">Left parameter.</param>
		/// <param name="student2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator ==(Student student1, Student student2)
		{
			return EqualityComparer<Student>.Default.Equals(student1, student2);
		}

		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="student1">Left parameter.</param>
		/// <param name="student2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator !=(Student student1, Student student2)
		{
			return !(student1 == student2);
		}
	}
}