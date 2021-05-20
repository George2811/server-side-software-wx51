using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync();


        Task<IEnumerable<Booking>> ListAsyncByHobbyistId(long Id);

        Task<BookingResponse> AssignBookingAsync(long HobbyistId, long EventId, DateTime attendance);
        Task<BookingResponse> UnassignBookingAsync(long HobbyistId, long EventId);
    }
}
