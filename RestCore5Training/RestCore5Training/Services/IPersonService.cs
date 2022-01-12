using RestCore5Training.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestCore5Training.Services
{
    public interface IPersonService
    {
         Person Create(Person person);
         Person FindById(long id);
         Task<List<Person>> FindAllAsync();
         Person Update(Person person);
         void Delete(long id);
    }
}