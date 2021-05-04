using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Contexts;
using PERUSTARS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public class HobbyistSpecialtyRepository : BaseRepository, IHobbyistSpecialtyRepository
    {
        public HobbyistSpecialtyRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(HobbyistSpecialty hobbyistSpecialty)
        {
            await _context.Interests.AddAsync(hobbyistSpecialty);
        }

        public async Task AssignHobbyistSpecialty(long hobbyistId, long specialtyId)
        {
            HobbyistSpecialty hobbyistSpecialty = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
            if(hobbyistSpecialty == null)
            {
                hobbyistSpecialty = new HobbyistSpecialty { HobbyistId = hobbyistId, SpecialtyId = specialtyId };
                await AddAsync(hobbyistSpecialty);
            }
        }

        public async Task<HobbyistSpecialty> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId)
        {
            return await _context.Interests.FindAsync(hobbyistId, specialtyId);
        }

        public async Task<IEnumerable<HobbyistSpecialty>> ListAsync()
        {
            return await _context.Interests
                .Include(hs => hs.Hobbyist)
                .Include(hs => hs.Specialty)
                .ToListAsync();
        }

        public async Task<IEnumerable<HobbyistSpecialty>> ListByHobbyistIdAsync(long hobbyistId)
        {
            return await _context.Interests
                .Where(hs => hs.HobbyistId == hobbyistId)
                .Include(hs => hs.Hobbyist)
                .Include(hs => hs.Specialty)
                .ToListAsync();
        }

        public void Remove(HobbyistSpecialty hobbyistSpecialty)
        {
            _context.Interests.Remove(hobbyistSpecialty);
        }

        public async void UnassignHobbyistSpecialty(long hobbyistId, long specialtyId)
        {
            HobbyistSpecialty hobbyistSpecialty = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
            if (hobbyistSpecialty != null)
            {
                Remove(hobbyistSpecialty);
            }
        }
    }
}
