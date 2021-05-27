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
    [Route("/api/artist/{artistId}/artworks")]
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


    }
}
