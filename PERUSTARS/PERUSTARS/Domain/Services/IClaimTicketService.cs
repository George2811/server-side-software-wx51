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

        Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long personId);

        Task<ClaimTicketResponse> GetByIdAndArtistIdAsync(long artistId, long claimTicketId);
        Task<ClaimTicketResponse> GetByIdAndHobbyistIdAsync(long hobbyistId, long claimTicketId);

        Task<ClaimTicketResponse> SaveByArtistIdAsync(long artistId, ClaimTicket claimTicket);
        Task<ClaimTicketResponse> SaveByHobbyistIdAsync(long hobbyistId, ClaimTicket claimTicket);

        Task<ClaimTicketResponse> UpdateByArtistIdAsync(long artistId, long claimTicketId, ClaimTicket claimTicket);
        Task<ClaimTicketResponse> UpdateByHobbyistIdAsync(long hobbyistId, long claimTicketId, ClaimTicket claimTicket);

        Task<ClaimTicketResponse> DeleteByArtistIdAsync(long artistId, long claimTicketId);
        Task<ClaimTicketResponse> DeleteByHobbyistIdAsync(long hobbyistId, long claimTicketId);
    }
}
