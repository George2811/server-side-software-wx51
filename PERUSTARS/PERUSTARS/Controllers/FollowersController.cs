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
        private readonly IHobbyistService _hobbyistService;
        private readonly IMapper _mapper;

        public FollowersController(IFollowerService followerService, IMapper mapper, IHobbyistService hobbyistService)
        {
            _followerService = followerService;
            _mapper = mapper;
            _hobbyistService = hobbyistService;
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
           Summary = "Get All Hobbyist By Artist Id",
           Description = "Get All Hobbyists By Artist Id",
           OperationId = "GetAllByArtistId")]
        [SwaggerResponse(200, "Get All By Artist Id", typeof(IEnumerable<HobbyistResource>))]

        [ProducesResponseType(typeof(IEnumerable<HobbyistResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpGet]
        public IEnumerable<HobbyistResource> GetAllByArtistIdAsync(int artistId)
        {
            var hobbyists = await _hobbyistService.ListByArtistIdAsync(artistId);
            var resources = _mapper.Map<IEnumerable<Hobbyist>, IEnumerable<HobbyistResource>>(hobbyists);
            return resources;
        }



        [SwaggerOperation(
           Summary = "Count Artist's Followers",
           Description = "Count Artist's Followers",
           OperationId = "CountFollowers")]
        [SwaggerResponse(200, "Count Followers", typeof(ArtistResource))]

        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpGet]
        public async Task<int> CountFollowers(long artistId)
        {
            var count = await _followerService.CountFollowers(artistId);
            return count;
        }
    }
}
