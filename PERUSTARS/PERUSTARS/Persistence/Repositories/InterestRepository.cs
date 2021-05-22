using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Contexts;
using PERUSTARS.Domain.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Persistence.Repositories
{
    public class InterestRepository : BaseRepository, IInterestRepository
    {
        public InterestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Interest hobbyistSpecialty)
        {
            await _context.Interests.AddAsync(hobbyistSpecialty);
        }

        public async Task AssignHobbyistSpecialty(long hobbyistId, long specialtyId)
        {
            Interest hobbyistSpecialty = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
            if (hobbyistSpecialty == null)
            {
                hobbyistSpecialty = new Interest { HobbyistId = hobbyistId, SpecialtyId = specialtyId };
                await AddAsync(hobbyistSpecialty);
            }
        }

        public async Task<Interest> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId)
        {
            return await _context.Interests.FindAsync(hobbyistId, specialtyId);
        }

        public async Task<IEnumerable<Interest>> ListAsync()
        {
            return await _context.Interests
                .Include(i => i.Hobbyist)
                .Include(i => i.Specialty)
                .ToListAsync();
        }

        public async Task<IEnumerable<Interest>> ListByHobbyistIdAsync(long hobbyistId)
        {
            return await _context.Interests
                .Where(i => i.HobbyistId == hobbyistId)
                .Include(i => i.Hobbyist)
                .Include(i => i.Specialty)
                .ToListAsync();
        }

        public void Remove(Interest hobbyistSpecialty)
        {
            _context.Interests.Remove(hobbyistSpecialty);
        }

        public async void UnassignHobbyistSpecialty(long hobbyistId, long specialtyId)
        {
            Interest hobbyistSpecialty = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
            if (hobbyistSpecialty != null)
                Remove(hobbyistSpecialty);

        }
    }
}
