using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IClaimTicketRepository
    {
        Task<IEnumerable<ClaimTicket>> ListAsync();
        Task<IEnumerable<ClaimTicket>> ListByPersonIdAsync(long personId);
        Task AddAsync(ClaimTicket claimTicket);
        Task<ClaimTicket> FindById(long id);
        void Update(ClaimTicket claimTicket);
        void Remove(ClaimTicket claimTicket);

    }
}
