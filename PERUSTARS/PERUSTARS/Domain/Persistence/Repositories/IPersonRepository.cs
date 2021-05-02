using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> ListAsync();
        Task AddAsync(Person person);
        Task<Person> FindById(long personId);
        void Update(Person person);
        void Remove(Person person);

    }
}
