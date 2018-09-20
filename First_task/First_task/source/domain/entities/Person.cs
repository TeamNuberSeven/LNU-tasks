using System;
using System.Collections.Generic;

namespace First_task.source.domain.entities
{
	/// <summary>
	/// Gives you base class for realisation of <see cref="Student"/> and <see cref="Teacher"/>.
	/// </summary>
	public abstract class Person
	{
		private string _name;
		private int _age;
		private string _id;

		/// <summary>
		/// Get/Set of <see cref="Person"/> name.
		/// </summary>
		public string Name
		{
			get => _name;
			set => _name = value.Replace("_", " ");
		}

		/// <summary>
		/// Get/Set of <see cref="Person"/> age.
		/// </summary>
		public int Age
		{
			get => _age;
			set => _age = value;
		}

		/// <summary>
		/// Get/Set of <see cref="Person"/> ID.
		/// </summary>
		public string Id
		{
			get => _id;
			set => _id = value;
		}

		/// <summary>
		/// Initialise new instance of <see cref="Person"/> class, which have default values.
		/// </summary>
		protected Person()
		{
			Name = string.Empty;
			Age = 0;
		}

		/// <summary>
		/// Initialise new instance of <see cref="Person"/> class, which have declared values.
		/// </summary>
		/// <param name="name"><see cref="Person"/> name.</param>
		/// <param name="age"><see cref="Person"/> age.</param>
		/// <param name="id"><see cref="Person"/> ID.</param>
		protected Person(string name, int age, string id)
		{
			Name = name.Replace("_", " ");
			Age = age;
			Id = id;
		}

		/// <summary>
		/// Converts <see cref="Person"/> value of this instance into string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age} ";
		}

		/// <summary>
		/// Gives value, which shows if this instance is equal to passed.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			var person = obj as Person;
			return person != null &&
			       Name == person.Name &&
			       Age == person.Age;
		}

		/// <summary>
		/// Gives hash code of this instance.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var hashCode = -1360180430;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Age.GetHashCode();
			return hashCode;
		}

		/// <summary>
		/// Prints this instance into <see cref="Console"/>.
		/// </summary>
		public virtual void Print()
		{
			Console.Write($"\nName: {Name} \nAge: {Age}");
		}

		/// <summary>
		/// Converts <see cref="data"/> into into instance of <see cref="Person"/> and sets this instance like that.
		/// </summary>
		/// <param name="data"><see cref="string"/> of data, compatible to this instance.</param>
		public virtual void Input(string data)
		{
			var words = data.Split(new[] {' '});
			Name = words[0];
			Age = int.Parse(words[1]);
		}


		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="person1">Left parameter.</param>
		/// <param name="person2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator ==(Person person1, Person person2)
		{
			return EqualityComparer<Person>.Default.Equals(person1, person2);
		}

		/// <summary>
		/// Compares two instances.
		/// </summary>
		/// <param name="person1">Left parameter.</param>
		/// <param name="person2">Right parameter.</param>
		/// <returns></returns>
		public static bool operator !=(Person person1, Person person2)
		{
			return !(person1 == person2);
		}
	}
}