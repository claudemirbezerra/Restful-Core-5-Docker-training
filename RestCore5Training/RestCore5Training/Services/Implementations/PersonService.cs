using System.Threading;
using RestCore5Training.Models;
using System.Collections.Generic;
using RestCore5Training.Models.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestCore5Training.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        private MySQLContext _context;

        public PersonService(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public async Task<List<Person>> FindAllAsync()
        {
            return await _context.Persons.ToListAsync();
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