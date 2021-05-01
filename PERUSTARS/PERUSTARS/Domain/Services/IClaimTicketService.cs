using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IClaimTicketService
    {
        Task<IEnumerable<ClaimTicket>> ListAsync();

        Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long Id);
        Task<ClaimTicketResponse> GetByIdAsync(long id);
        Task<ClaimTicketResponse> SaveAsync(ClaimTicket claimTicket);
        Task<ClaimTicketResponse> UpdateAsync(long id, ClaimTicket claimTicket);
        Task<ClaimTicketResponse> DeleteAsync(long id);
    }
}
