using System.Collections.Generic;
using System.IO;
using First_task.source.domain.entities;
using Newtonsoft.Json.Linq;

namespace First_task.source.data
{
	/// <summary>
	/// Implementation of <see cref="IPersonRepository"/>.
	/// </summary>
	public class PersonRepository : IPersonRepository
    {
        private const string FILE_PATH = "..//..//source/data/data_source/DataBase.json";

        /// <summary>
        /// Fetch data.
        /// </summary>
        /// <returns></returns>
        public List<Person> Fetch()
        {
            var data = new List<Person>();
            var personList = JObject.Parse(File.ReadAllText(FILE_PATH));
            data.AddRange(Parse<Teacher>(personList["Teachers"]));
            data.AddRange(Parse<Student>(personList["Students"]));
            return data;
        }

        private List<T> Parse<T>(JToken rawData)
        {
            var data = new List<T>();
            rawData.Children().ToList().ForEach((person) =>
            {
                data.Add(person.ToObject<T>());
            });
            return data;
        }
    }
}