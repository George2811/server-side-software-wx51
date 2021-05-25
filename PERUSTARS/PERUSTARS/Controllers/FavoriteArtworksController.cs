using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Extensions;
using PERUSTARS.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FavoriteArtworksController : ControllerBase
    {
        private readonly IFavoriteArtworkService _favoriteArtworkService;
        private readonly IArtworkService _artworkService;
        private readonly IMapper _mapper;

        public FavoriteArtworksController(IFavoriteArtworkService favoriteArtworkService, IMapper mapper, IArtworkService artworkService)
        {
            _favoriteArtworkService = favoriteArtworkService;
            _mapper = mapper;
            _artworkService = artworkService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtworkResource>> GetAllByHobbyistIdAsync(long hobbyistId)
        {
            var artworks = await _artworkService.ListByHobbyistAsync(hobbyistId);
            var resources = _mapper.Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artworks);
            return resources;
        }

        [HttpPost("{artworkId}")]
        public async Task<IActionResult> AssignArtwork(long hobbyistId, long artworkId)
        {
            var result = await _favoriteArtworkService.AssignFavoriteArtworkAsync(hobbyistId, artworkId);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource.Artwork);
            return Ok(artworkResource);
        }

        [HttpDelete("{artworkId}")]
        public async Task<IActionResult> UnassignBooking(long hobbyistId, long artworkId)
        {
            var result = await _favoriteArtworkService.UnassignFavoriteArtworkAsync(hobbyistId, artworkId);
            if (!result.Success)
                return BadRequest(result.Message);
            var favoriteArtworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource.Artwork);
            return Ok(favoriteArtworkResource);
        }
    }
}
