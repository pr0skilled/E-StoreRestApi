using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Database;
using E_StoreRestApi.Models.Shared;
using E_StoreRestApi.Repositories.Interfaces;

namespace E_StoreRestApi.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private EStoreDbContext db;

        public PersonRepository(EStoreDbContext context_)
        {
            db = context_;
        }

        public Person FindPersonById(long id)
        {
            var person = db.People.Find(id);
            return person;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = db.People;
            return people;
        }

        public void SavePerson(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            db.People.Update(person);
            db.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            db.People.Remove(person);
            db.SaveChanges();
        }
    }
}
