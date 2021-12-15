using System.Threading;
using RestCore5Training.Models;
using System.Collections.Generic;

namespace RestCore5Training.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia = Minas",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int id) 
        {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "PersonName" + id,
                LastName = "PersonLastName" + id,
                Address = "SomeAddress" + id,
                Gender = "Male"
            };            
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}