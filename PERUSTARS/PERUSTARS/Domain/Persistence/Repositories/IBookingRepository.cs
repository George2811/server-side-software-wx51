
using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();
        Task AddAsync(Booking booking);
        Task<IEnumerable<Booking>> ListByEventIdAsync(long eventId);
        Task<IEnumerable<Booking>> ListByHobbyistIdAsync(long hobbyistId);

        Task<Booking> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId);

        Task AssignBooking(long hobbyistId, long eventId, DateTime attendance);
        Task UnassignBooking(long hobbyistId, long eventId);

        void Remove(Booking booking);
    }
}
