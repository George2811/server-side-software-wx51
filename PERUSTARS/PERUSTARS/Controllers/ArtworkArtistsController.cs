using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Services;
using System;
using PERUSTARS.Domain.Models;
using PERUSTARS.Resources;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using PERUSTARS.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ArtworkArtistsController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        private readonly IMapper _mapper;

        public ArtworkArtistsController(IArtworkService artworkService, IMapper mapper)
        {
            _artworkService = artworkService;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<IEnumerable<ArtworkResource>> GetAllByArtistIdAsync(long artistId)
        {
            var artworks = await _artworkService.ListByArtistIdAsync(artistId);
            var resources = _mapper.Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artworks);
            return resources;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveArtworkResource resource, long artistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var artwork = _mapper.Map<SaveArtworkResource, Artwork>(resource);
            artwork.ArtistId = artistId;
            var result = await _artworkService.SaveAsync(artwork);

            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);

        }

    }
}
