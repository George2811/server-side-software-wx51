using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IInterestRepository
    {
        Task<IEnumerable<Interest>> ListAsync();
        Task<IEnumerable<Interest>> ListByHobbyistIdAsync(long hobbyistId);
        Task<Interest> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId);
        Task AddAsync(Interest hobbyistSpecialty);
        void Remove(Interest hobbyistSpecialty);
        Task AssignHobbyistSpecialty(long hobbyistId, long specialtyId);
        void UnassignHobbyistSpecialty(long hobbyistId, long specialtyId);

    }
}
