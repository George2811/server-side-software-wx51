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

        public Task AddAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task AssignBookingTag(long hobbyistId, long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> ListByEventIdAsync(long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> ListByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> ListByHobbyistIdAsync(long hobbyistId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void UnassignBookingTag(long hobbyistId, long eventId)
        {
            throw new NotImplementedException();
        }
    }
}
