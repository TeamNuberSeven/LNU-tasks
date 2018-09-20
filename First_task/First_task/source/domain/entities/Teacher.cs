using System;
using System.Collections.Generic;
using System.Linq;

namespace First_task.source.domain.entities
{
	/// <summary>
	/// Implementation of <see cref="Person"/>.
	/// </summary>
	public class Teacher : Person
	{
		private string _degree;
		private string _subject;
		private List<string> _studentsId;

		/// <summary>
		/// Get/Set of <see cref="Teacher"/> degree.
		/// </summary>
		public string Degree
		{
			get => _degree;
			set => _degree = value;
		}

		/// <summary>
		/// Get/Set of <see cref="Teacher"/> subject.
		/// </summary>
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

		/// <summary>
		/// Initialise new instance of <see cref="Teacher"/> class, which have default values.
		/// </summary>
		public Teacher()
		{
			Degree = string.Empty;
			Subject = string.Empty;
			StudentsId = new List<string>();
		}

		/// <summary>
		/// Initialise new instance of <see cref="Teacher"/> class, which have declared values.
		/// </summary>
		/// <param name="name"><see cref="Teacher"/> name.</param>
		/// <param name="age"><see cref="Teacher"/> age.</param>
		/// <param name="id"><see cref="Teacher"/> id.</param>
		/// <param name="degree"><see cref="Teacher"/> degree.</param>
		/// <param name="subject"><see cref="Teacher"/> subject.</param>
		public Teacher(string name, int age,string id, string degree, string subject) : base(name, age,id)
		{
			Degree = degree;
			Subject = subject;			
		}

		/// <summary>
		/// Converts <see cref="Teacher"/> value of this instance into string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age}, Degree {Degree}, Subject: {Subject}" +
			       StudentsId.Aggregate("", (current, student) => current + " " + student);
		}

		/// <summary>
		/// Assigning students into this <see cref="Teacher"/>.
		/// </summary>
		/// <param name="students"><see cref="List{T}"/> of <see cref="Student"/>.</param>
		public void AssignStudents(List<Student> students)
		{
			foreach (Student stud in students)
			{
				StudentsId.Add(stud.Id);
				stud.TeacherId = Id;
			}
		}

		/// <summary>
		/// Prints this instance into <see cref="Console"/>.
		/// </summary>
		public override void Print()
		{
			base.Print();
			Console.WriteLine($"\nDegree:  {Degree} \nSubject: {Subject}");
			foreach (var student in StudentsId)
			{
				Console.WriteLine(student);
			}
		}

		/// <summary>
		/// Converts <see cref="data"/> into into instance of <see cref="Teacher"/> and sets this instance like that.
		/// </summary>
		/// <param name="data"><see cref="string"/> of data, compatible to this instance.</param>
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

		/// <summary>
		/// Gives value, which shows if this instance is equal to passed.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			var teacher = obj as Teacher;
			return teacher != null &&
			       base.Equals(obj) &&
			       Degree == teacher.Degree &&
			       Subject == teacher.Subject &&
			       EqualityComparer<List<string>>.Default.Equals(StudentsId, teacher.StudentsId);
		}

		/// <summary>
		/// Gives hash code of this instance.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = 1332502943;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Degree);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(StudentsId);
			return hashCode;
		}

		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="teacher1">Left parameter.</param>
		/// <param name="teacher2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator ==(Teacher teacher1, Teacher teacher2)
		{
			return EqualityComparer<Teacher>.Default.Equals(teacher1, teacher2);
		}

		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="teacher1">Left parameter.</param>
		/// <param name="teacher2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator !=(Teacher teacher1, Teacher teacher2)
		{
			return !(teacher1 == teacher2);
		}
	}
}