using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IEventAssistanceService
    {
        Task<IEnumerable<EventAssistance>> ListAsync();


        Task<IEnumerable<EventAssistance>> ListAsyncByHobbyistId(long Id);

        Task<BookingResponse> AssignBookingAsync(long HobbyistId, long EventId, DateTime attendance);
        Task<BookingResponse> UnassignBookingAsync(long HobbyistId, long EventId);
    }
}
