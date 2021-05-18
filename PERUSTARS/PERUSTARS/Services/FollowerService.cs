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
    public class FollowerService :IFollowerService
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FollowerService(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FollowerResponse> AssignFollowerAsync(long HobbyistId, long ArtistId)
        {
            try {
                await _followerRepository.AssignFollower(HobbyistId,ArtistId);
                await _unitOfWork.CompleteAsync();
                Follower follower = await _followerRepository.FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
                return new FollowerResponse(follower);
            }
            catch (Exception ex) { 
            return new FollowerResponse($"An error ocurred while assign Artist to Hobbyist: {ex.Message}");
            }
        }

        public async Task<int> CountFollowers(long ArtistId)
        {
            return await _followerRepository.CountFollower(ArtistId);
        }

        public async Task<IEnumerable<Follower>> ListAsync()
        {
            return await _followerRepository.ListAsync();
        }

        public async Task<IEnumerable<Follower>> ListByArtistAsync(long Id)
        {
            return await _followerRepository.ListByArtistIdAsync(Id);
        }

        public async Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long Id)
        {
            return await _followerRepository.ListByHobbyistIdAsync(Id);
        }

        public async Task<FollowerResponse> UnassignFollowerAsync(long HobbyistId, long ArtistId)
        {
            try
            {
                Follower follower = await _followerRepository.FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
                _followerRepository.UnassignFollower(HobbyistId, ArtistId);
                await _unitOfWork.CompleteAsync();
                return new FollowerResponse(follower);
            }
            catch (Exception ex)
            {
                return new FollowerResponse($"An error ocurred while unassign Artist to Hobbyist: {ex.Message}");
            }
        }
    }
}
