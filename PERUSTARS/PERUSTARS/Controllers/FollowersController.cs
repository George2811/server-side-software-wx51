using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("/api/artists/{artistId}/followers")]
    [Produces("application/json")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly IFollowerService _followerService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public FollowersController(IFollowerService followerService, IArtistService artistService, IMapper mapper)
        {
            _followerService = followerService;
            _artistService = artistService;
            _mapper = mapper;
        }


        [SwaggerOperation(
           Summary = "Assign Follower",
           Description = "Assign Follower",
           OperationId = "AssignFollower")]
        [SwaggerResponse(200, "Assign Follower", typeof(IActionResult))]

        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpPost("{hobbyistId}")]
        public async Task<IActionResult> AssignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.AssignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist);
            return Ok(artistResource);
        }


        [SwaggerOperation(
           Summary = "Unassign Follower",
           Description = "Unassign Follower",
           OperationId = "UnassignFollower")]
        [SwaggerResponse(200, "Unassign Follower", typeof(IActionResult))]

        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpDelete("{hobbyistId}")]
        public async Task<IActionResult> UnassignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.UnassignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist);
            return Ok(artistResource);
        }


        [SwaggerOperation(
           Summary = "Get All Artists By Hobbyist Id",
           Description = "Get All Artists By Hobbyist Id",
           OperationId = "GetAllByHobbyistId")]
        [SwaggerResponse(200, "Get All By HobbyistId", typeof(ArtistResource))]

        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpGet("{hobbyistId}")]
        public async Task<IEnumerable<ArtistResource>> GetAllByHobbyistIdAsync(int hobbyistId)
        {
            var artists = await _artistService.ListByHobbyistIdAsync(hobbyistId);
            var resources = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistResource>>(artists);
            return resources;
        }


        [SwaggerOperation(
           Summary = "Count Artist's Followers",
           Description = "Count Artist's Followers",
           OperationId = "CountFollowers")]
        [SwaggerResponse(200, "Count Followers", typeof(ArtistResource))]

        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpGet()]
        public async Task<int> CountFollowers(long artistId)
        {
            var count = await _followerService.CountFollowers(artistId);
            return count;
        }
    }
}
