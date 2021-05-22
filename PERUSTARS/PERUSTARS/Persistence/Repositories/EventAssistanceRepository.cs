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
    public class EventAssistanceRepository : BaseRepository, IEventAssistanceRepository
    {
        public EventAssistanceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(EventAssistance booking)
        {           
            await _context.Bookings.AddAsync(booking);
        }

        public async Task AssignBooking(long hobbyistId, long eventId, DateTime attendance)
        {
            EventAssistance booking = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            if (booking == null)
            {
                booking = new EventAssistance { HobbyistId = hobbyistId, EventId = eventId  , AttendanceDay = attendance};
                await AddAsync(booking);
            }

        }

        public async Task<IEnumerable<EventAssistance>> ListAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<IEnumerable<EventAssistance>> ListByEventIdAsync(long eventId)
        {
            return await _context.Bookings
                   .Where(pt => pt.EventId == eventId)
                   .Include(pt => pt.Event)
                   .Include(pt => pt.Hobbyist)
                   .ToListAsync();
        }

        public async Task<EventAssistance> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId)
        {
            return await _context.Bookings.FindAsync(hobbyistId,eventId);
        }

        public async Task<IEnumerable<EventAssistance>> ListByHobbyistIdAsync(long hobbyistId)
        {
            return await _context.Bookings
                 .Where(pt => pt.HobbyistId == hobbyistId)
                 .Include(pt => pt.Event)
                 .Include(pt => pt.Hobbyist)
                 .ToListAsync();
        }

        public void Remove(EventAssistance booking)
        {
            _context.Bookings.Remove(booking);
        }

        public async Task UnassignBooking(long hobbyistId, long eventId)
        {
            EventAssistance booking = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            if (booking != null)
                Remove(booking);
        }
    }
}
