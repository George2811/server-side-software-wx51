using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> ListAsync();
        Task<PersonResponse> GetByIdAsync(long id);
        Task<PersonResponse> SaveAsync(Person person);
        Task<PersonResponse> UpdateAsync(long id, Person person);
        Task<PersonResponse> DeleteAsync(long id);
    }
}
