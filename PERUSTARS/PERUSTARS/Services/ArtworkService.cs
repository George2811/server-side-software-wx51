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
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArtworkService(IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            _artworkRepository = artworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkResponse> DeleteAsync(long id)
        {
            var existingArtwork = await _artworkRepository.FindById(id);

            if (existingArtwork == null)
                return new ArtworkResponse("Artwork not found");

            try
            {
                _artworkRepository.Remove(existingArtwork);
                await _unitOfWork.CompleteAsync();

                return new ArtworkResponse(existingArtwork);
            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error ocurred while deleting the artwork: {ex.Message}");
            }
        }

        public async Task<ArtworkResponse> GetByIdAsync(long id)
        {
            var existingArtwork = await _artworkRepository.FindById(id);

            if (existingArtwork == null)
                return new ArtworkResponse("Artwork not found");
            return new ArtworkResponse(existingArtwork);
        }

        public async Task<bool> isSameTitle(string title, long ArtistId)
        {
            return await _artworkRepository.isSameTitle(title, ArtistId);
        }

        public async Task<IEnumerable<Artwork>> ListAsync()
        {
            return await _artworkRepository.ListAsync();
        }

        public async Task<IEnumerable<Artwork>> ListByArtistIdAsync(long id)
        {
            return await _artworkRepository.ListByArtistIdAsync(id);
        }

        public async Task<ArtworkResponse> SaveAsync(Artwork artwork)
        {

            if (_artworkRepository.isSameTitle(artwork.ArtTitle, artwork.ArtistId).Result == true)
            {
                return new ArtworkResponse($"You already created an artwork with the same title");
            }

            try
            {
                await _artworkRepository.AddAsync(artwork);
                await _unitOfWork.CompleteAsync();

                return new ArtworkResponse(artwork);
            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error ocurred while saving the artwork: {ex.Message}");
            }
        }

        public async Task<ArtworkResponse> UpdateAsync(long id, Artwork artwork)
        {
            var existingArtwork = await _artworkRepository.FindById(id);

            if (existingArtwork == null)
                return new ArtworkResponse("Artist not found");

            if (existingArtwork.ArtTitle != artwork.ArtTitle)
            { // si el titulo nuevo es diferente al titulo existente
                if (_artworkRepository.isSameTitle(artwork.ArtTitle, id).Result == true) // se verifica si el titulo nuevo es igual a cualquier titulo de obras del artista
                {
                    return new ArtworkResponse($"You already created an artwork with the same title");
                }
            }


            existingArtwork.ArtTitle = artwork.ArtTitle;
            existingArtwork.ArtDescription = artwork.ArtDescription;
            existingArtwork.ArtCost = artwork.ArtCost;
            existingArtwork.LinkInfo = artwork.LinkInfo;

            try
            {
                _artworkRepository.Update(existingArtwork);
                await _unitOfWork.CompleteAsync();

                return new ArtworkResponse(existingArtwork);
            }
            catch (Exception ex)
            {
                return new ArtworkResponse($"An error ocurred while updating the artwork: {ex.Message}");
            }
        }
    }
}
