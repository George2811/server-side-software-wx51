using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.Persistence.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public async Task<Person> FindById(long personId)
        {
            return await _context.Hobbyists.FindAsync(personId);
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public void Remove(Person person)
        {
            _context.Persons.Remove(person);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }
    }
}
