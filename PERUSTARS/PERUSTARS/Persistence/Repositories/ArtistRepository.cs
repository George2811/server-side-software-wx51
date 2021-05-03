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
    public class ArtistRepository : BaseRepository, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
        }

        public async Task<Artist> FindById(long id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<IEnumerable<Artist>> ListAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public void Remove(Artist artist)
        {
            _context.Artists.Remove(artist);
        }

        public void Update(Artist artist)
        {
            _context.Artists.Update(artist);
        }
    }
}
