
using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IEventAssistanceRepository
    {
        Task<IEnumerable<EventAssistance>> ListAsync();
        Task AddAsync(EventAssistance booking);
        Task<IEnumerable<EventAssistance>> ListByEventIdAsync(long eventId);
        Task<IEnumerable<EventAssistance>> ListByHobbyistIdAsync(long hobbyistId);

        Task<EventAssistance> FindByHobbyistIdAndEventIdAsync(long hobbyistId, long eventId);

        Task AssignBooking(long hobbyistId, long eventId, DateTime attendance);
        Task UnassignBooking(long hobbyistId, long eventId);

        void Remove(EventAssistance booking);
    }
}
