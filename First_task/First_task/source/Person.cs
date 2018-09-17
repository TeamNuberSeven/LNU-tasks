﻿using System;
using System.Collections.Generic;

namespace First_task.source
{
	abstract class Person
	{
		private string _name;
		private int _age;

		public string Name
		{
			get => _name;
			set => _name = value.Replace(" ", "_");
		}

		public int Age
		{
			get => _age;
			set => _age = value;
		}

		protected Person()
		{
			Name = string.Empty;
			Age = 0;
		}

		protected Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			return $"\nName: {Name}, Age: {Age} ";
		}

		public override bool Equals(object obj)
		{
			var person = obj as Person;
			return person != null &&
			       Name == person.Name &&
			       Age == person.Age;
		}

		public override int GetHashCode()
		{
			var hashCode = -1360180430;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Age.GetHashCode();
			return hashCode;
		}

		public virtual void Print()
		{
			Console.WriteLine($"\nName: {0} \nAge: {1}", Name, Age);
		}

		public virtual void Input(string data)
		{
			var words = data.Split(new[] {' '});
			Name = words[0];
			Age = int.Parse(words[1]);
		}


		public static bool operator ==(Person person1, Person person2)
		{
			return EqualityComparer<Person>.Default.Equals(person1, person2);
		}

		public static bool operator !=(Person person1, Person person2)
		{
			return !(person1 == person2);
		}
	}
}