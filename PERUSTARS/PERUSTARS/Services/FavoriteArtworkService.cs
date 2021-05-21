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
    public class FavoriteArtworkService : IFavoriteArtworkService
    {
        private readonly IFavoriteArtworkRepository _favoriteArtworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteArtworkService(IFavoriteArtworkRepository favoriteArtworkRepository, IUnitOfWork unitOfWork)
        {
            _favoriteArtworkRepository = favoriteArtworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FavoriteArtworkResponse> AssignFavoriteArtworkAsync(long HobbyistId, long ArtworkId)
        {
            try {
                await _favoriteArtworkRepository.AssignFavoriteArtwork(HobbyistId, ArtworkId);
                await _unitOfWork.CompleteAsync();
                FavoriteArtwork favoriteArtwork = await _favoriteArtworkRepository.FindByHobbyistIdAndArtworkId(HobbyistId, ArtworkId);
                return new FavoriteArtworkResponse(favoriteArtwork);
            }
            catch (Exception ex) { 
            return new FavoriteArtworkResponse($"An error ocurred while assign Artwork to Hobbyist: {ex.Message}");
            }
            
        }

        public async Task<IEnumerable<FavoriteArtwork>> ListAsync()
        {
            return await _favoriteArtworkRepository.ListAsync();
        }

        public async Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long Id)
        {
            return await _favoriteArtworkRepository.ListByHobbyistIdAsync(Id);
        }

        public async Task<FavoriteArtworkResponse> UnassignFavoriteArtworkAsync(long HobbyistId, long ArtworkId)
        {
            try
            {
                FavoriteArtwork favoriteArtwork = await _favoriteArtworkRepository.FindByHobbyistIdAndArtworkId(HobbyistId, ArtworkId);
                _favoriteArtworkRepository.UnassignFavoriteArtwork(HobbyistId,ArtworkId);
                await _unitOfWork.CompleteAsync();
                return new FavoriteArtworkResponse(favoriteArtwork);

            }
            catch (Exception ex)
            { 
                return new FavoriteArtworkResponse($"An error ocurred while unassign Artwork to Hobbyist: {ex.Message}");
            }
        }
    }
}
