using System.Collections.Generic;
using First_task.source.domain.entities;

namespace First_task.source.data
{
    public interface IPersonRepository
    {
        List<Person> Fetch();
    }
}