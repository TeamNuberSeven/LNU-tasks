using System.Collections.Generic;
using First_task.source.domain.entities;

namespace First_task.source.data
{
	/// <summary>
	/// Gives you base interface for realisation of <see cref="PersonRepository"/>.
	/// </summary>
	public interface IPersonRepository
    {
        /// <summary>
        /// Fetch data.
        /// </summary>
        /// <returns></returns>
        List<Person> Fetch();
    }
}