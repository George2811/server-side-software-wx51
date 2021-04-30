using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> ListAsync();
        Task<ArtistResponse> GetByIdAsync(int id);
        Task<ArtistResponse> SaveAsync(Artist artist);
        Task<ArtistResponse> UpdateAsync(int id, Artist artist);
        Task<ArtistResponse> DeleteAsync(int id);
    }
}
