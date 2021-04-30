using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Domain.Services;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistService;
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IArtistRepository artistService, IUnitOfWork unitOfWork)
        {
            _artistService = artistService;
            _unitOfWork = unitOfWork;
        }

        public Task<ArtistResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artist>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArtistResponse> SaveAsync(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Task<ArtistResponse> UpdateAsync(int id, Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
