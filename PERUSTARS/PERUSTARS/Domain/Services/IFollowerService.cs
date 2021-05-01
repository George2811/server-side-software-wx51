using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Services
{
    public interface IFollowerService
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long Id); //Halla los artistas a los cuales sigue el aficionado

        Task<IEnumerable<Follower>> ListByArtistAsync(long Id); //Halla los aficionados que siguen al artista

        Task<FollowerResponse> CountFollowers(long Id); // Cuenta los seguidores del artista

        Task<FollowerResponse> AssignFollowerAsync(long HobbyistId, long ArtworkId);
        Task<FollowerResponse> UnassignFollowerAsync(long HobbyistId, long ArtworkId);
    }
}
