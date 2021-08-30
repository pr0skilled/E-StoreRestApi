using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Models.Shared;

namespace E_StoreRestApi.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Person FindPersonById(long id);
        IEnumerable<Person> GetAllPeople();
        void SavePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
