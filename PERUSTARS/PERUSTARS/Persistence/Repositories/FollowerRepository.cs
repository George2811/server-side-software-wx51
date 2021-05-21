using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Persistence.Contexts;
using PERUSTARS.Domain.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Persistence.Repositories
{
    public class FollowerRepository : BaseRepository, IFollowerRepository
    {
        public FollowerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Follower follower)
        {
            await _context.Followers.AddAsync(follower);
        }

        public async Task AssignFollower(long HobbyistId, long ArtistId)
        {
            Follower follower = await FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
            if (follower == null)
            {
                follower = new Follower { HobbyistId = HobbyistId, ArtistId = ArtistId };
                await AddAsync(follower);
            }
        }

        public async Task<int> CountFollower(long ArtistId)
        {
            return await _context.Followers
               .Where(pt => pt.ArtistId == ArtistId)
               .Include(pt => pt.Artist)
               .Include(pt => pt.Hobbyist)
               .CountAsync();
               
        }

        public async Task<Follower> FindByHobbyistIdAndArtistId(long HobbyistId, long ArtistId)
        {
            return await _context.Followers.FindAsync(HobbyistId, ArtistId);
        }

        public async Task<IEnumerable<Follower>> ListAsync()
        {
            return await _context.Followers.ToListAsync();
        }

        public async Task<IEnumerable<Follower>> ListByArtistIdAsync(long ArtistId)
        {
            return await _context.Followers
                .Where(pt => pt.ArtistId == ArtistId)
                .Include(pt => pt.Artist)
                .Include(pt => pt.Hobbyist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long HobbyistId)
        {
            return await _context.Followers
               .Where(pt => pt.HobbyistId == HobbyistId)
               .Include(pt => pt.Artist)
               .Include(pt => pt.Hobbyist)
               .ToListAsync();
        }

        public void Remove(Follower follower)
        {
            _context.Followers.Remove(follower);
        }

        public async Task UnassignFollower(long HobbyistId, long ArtistId)
        {
            Follower follower = await FindByHobbyistIdAndArtistId(HobbyistId, ArtistId);
            if (follower != null)
                Remove(follower);
        }
    }
}
