using System;
using System.Collections.Generic;
using System.IO;
using First_task.source.data;
using First_task.source.domain.entities;
using First_task.source.presentation;

namespace First_task.source.domain.use_cases
{
	public class FetchPersons
	{
		private readonly IPersonRepository _repo;
	    private IMainView _view;
	    private const string FILE_PATH_ERROR = "Sorry data source is invalid, we work to resolve this issue";
	    private const string FILE_FORMAT_ERROR = "Sorry data was corrupted, we work to resolve this issue";

        public FetchPersons(IPersonRepository repo)
		{
			_repo = repo;
		}

	    public IMainView View
	    {
	        set => _view = value;
	    }

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