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
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Event _event)
        {
            await _context.Events.AddAsync(_event);
        }

        public async Task<Event> FindById(long id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> ListByArtistIdAsync(long artistId) //falta implementar
        {
            return await _context.Events
                  .Where(pt => pt.ArtistId == artistId)
                  .ToListAsync();
        }

        public void Remove(Event _event)
        {
            _context.Events.Remove(_event);
        }

        public void Update(Event _event)
        {
            _context.Events.Update(_event);
        }
    }
}
