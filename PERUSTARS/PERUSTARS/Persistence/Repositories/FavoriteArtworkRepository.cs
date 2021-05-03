using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.Persistence.Repositories
{
    public class FavoriteArtworkRepository : BaseRepository, IFavoriteArtworkRepository
    {
        public FavoriteArtworkRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FavoriteArtwork favoriteArtwork)
        {
            await _context.FavoriteArtworks.AddAsync(favoriteArtwork);
        }

        public async Task AssignFavoriteArtwork(long HobbyistId, long ArtworkId)
        {
            FavoriteArtwork favoriteArtwork = await FindByHobbyistIdAndArtworkId(HobbyistId, ArtworkId);
            if (favoriteArtwork == null)
            {
                favoriteArtwork = new FavoriteArtwork { HobyyistId = HobbyistId , ArtworkId = ArtworkId };
                await AddAsync(favoriteArtwork);
            }
        }

        public async Task<FavoriteArtwork>FindByHobbyistIdAndArtworkId(long HobbyistId, long ArtworkId)
        {
            return await _context.FavoriteArtworks.FindAsync(HobbyistId, ArtworkId);
        }

        public async Task<IEnumerable<FavoriteArtwork>> ListAsync()
        {
            return await _context.FavoriteArtworks.ToListAsync();
        }

        public async Task<IEnumerable<FavoriteArtwork>> ListByArtworkIdAsync(long ArtworkId)
        {
            return await _context.FavoriteArtworks
                 .Where(pt => pt.ArtworkId == ArtworkId)
                 .Include(pt => pt.Artwork)
                 .Include(pt => pt.Hobbyist)
                 .ToListAsync();
        }

        public async Task<IEnumerable<FavoriteArtwork>> ListByHobbyistIdAsync(long HobbyistId)
        {
            return await _context.FavoriteArtworks
                 .Where(pt => pt.HobyyistId == HobbyistId)
                 .Include(pt => pt.Artwork)
                 .Include(pt => pt.Hobbyist)
                 .ToListAsync();
        }

        public void Remove(FavoriteArtwork favoriteArtwork)
        {
            _context.FavoriteArtworks.Remove(favoriteArtwork);
        }

        public async Task UnassignFavoriteArtwork(long HobbyistId, long ArtworkId)
        {
            FavoriteArtwork favoriteArtwork = await FindByHobbyistIdAndArtworkId(HobbyistId, ArtworkId);
            if (favoriteArtwork != null)
                Remove(favoriteArtwork);
        }
    }
}
