using System;
using System.Collections.Generic;
using System.IO;
using First_task.source.data;
using First_task.source.domain.entities;
using First_task.source.presentation;

namespace First_task.source.domain.use_cases
{
	/// <summary>
	/// Use case to fetch base data in format <see cref="Person"/>/<see cref="Teacher"/>/<see cref="Student"/>.
	/// </summary>
	public class FetchPersons
	{
		private readonly IPersonRepository _repo;
	    private IMainView _view;
	    private const string FILE_PATH_ERROR = "Sorry data source is invalid, we work to resolve this issue";
	    private const string FILE_FORMAT_ERROR = "Sorry data was corrupted, we work to resolve this issue";

		/// <summary>
		/// Initialise new instance of <see cref="FetchPersons"/> class, which have declared repository.
		/// </summary>
		/// <param name="repo"></param>
		public FetchPersons(IPersonRepository repo)
		{
			_repo = repo;
		}

	    /// <summary>
	    /// Reference to presentation layer.
	    /// </summary>
	    public IMainView View
	    {
	        set => _view = value;
	    }

		/// <summary>
		/// Fetch data from repository.
		/// </summary>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		/// <returns></returns>
		public List<Person> Fetch()
		{
		    try
		    {
		        return _repo.Fetch();
		    }
		    catch (FileNotFoundException)
		    {
		        _view.PrintError(FILE_PATH_ERROR);
		    }
		    catch (ArgumentException)
		    {
		        _view.PrintError(FILE_FORMAT_ERROR);
		    }
		    catch (NullReferenceException)
		    {
		        _view.PrintError(FILE_FORMAT_ERROR);
            }

		    return null;
		}
	}
}