using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Repositories
{
    public interface IHobbyistSpecialtyRepository
    {
        Task<IEnumerable<HobbyistSpecialty>> ListAsync();
        Task<IEnumerable<HobbyistSpecialty>> ListByHobbyistIdAsync(long hobbyistId);
        Task<HobbyistSpecialty> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId);
        Task AddAsync(HobbyistSpecialty hobbyistSpecialty);
        void Remove(HobbyistSpecialty hobbyistSpecialty);
        Task AssignHobbyistSpecialty(long hobbyistId, long specialtyId);
        void UnassignHobbyistSpecialty(long hobbyistId, long specialtyId);

    }
}
