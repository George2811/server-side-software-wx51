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
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Booking booking)
        {           
            await _context.Bookings.AddAsync(booking);
        }

        public async Task AssignBookingTag(long hobbyistId, long eventId)
        {
            Booking booking = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            if (booking == null)
            {
                booking = new Booking { HobbyistId = hobbyistId, EventId = eventId  };
                await AddAsync(booking);
            }

        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> ListByEventIdAsync(long eventId)
        {
            return await _context.Bookings
                   .Where(pt => pt.EventId == eventId)
                   .Include(pt => pt.Event)
                   .Include(pt => pt.Hobbyist)
                   .ToListAsync();
        }

        public async Task<Booking> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId)
        {
            return await _context.Bookings.FindAsync(hobbyistId,eventId);
        }

        public async Task<IEnumerable<Booking>> ListByHobbyistIdAsync(long hobbyistId)
        {
            return await _context.Bookings
                 .Where(pt => pt.HobbyistId == hobbyistId)
                 .Include(pt => pt.Event)
                 .Include(pt => pt.Hobbyist)
                 .ToListAsync();
        }

        public void Remove(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

        public async Task UnassignBookingTag(long hobbyistId, long eventId)
        {
            Booking booking = await FindByHobbyistIdAndEventIdAsync(hobbyistId, eventId);
            if (booking != null)
                Remove(booking);
        }
    }
}
