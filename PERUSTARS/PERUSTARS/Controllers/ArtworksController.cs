using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.Domain.Models;
using PERUSTARS.Resources;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using PERUSTARS.Extensions;


namespace PERUSTARS.Controllers
{
    [ApiController]
    [Route("/api/artist/{artistId}/artworks")]
    [Produces("application/json")]
    public class ArtworksController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        private readonly IMapper _mapper;

        public ArtworksController(IArtworkService artowrkService, IMapper mapper)
        {
            _artworkService = artowrkService;
            _mapper = mapper;
        }


        /*****************************************************************/
                               /*LIST OF ARTWORKS*/
        /*****************************************************************/


        [HttpGet]
        public async Task<IEnumerable<ArtworkResource>> GetAllByArtistIdAsync(long artistId)
        {
            var artworks = await _artworkService.ListByArtistIdAsync(artistId);
            var resources = _mapper.Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artworks);
            return resources;
        }


        /*****************************************************************/
                            /*GET ARTWORKS BY ID*/
        /*****************************************************************/

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(int id, int artistId)
        {
            var result = await _artworkService.GetByIdAndArtistIdAsync(id, artistId);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);
        }





        /*****************************************************************/
                                /*SAVE ARTWORK*/
        /*****************************************************************/


<<<<<<< HEAD
        [HttpPost]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveArtworkResource resource, long artistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var artwork = _mapper.Map<SaveArtworkResource, Artwork>(resource);
            var result = await _artworkService.SaveAsync(artistId, artwork);

            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);

        }
=======
       
>>>>>>> develop




        /*****************************************************************/
                                /*UPDATE ARTWORK*/
        /*****************************************************************/


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, int artistId, [FromBody] SaveArtworkResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var artwork = _mapper.Map<SaveArtworkResource, Artwork>(resource);
            var result = await _artworkService.UpdateAsync(id, artistId, artwork);

            if (!result.Success)
                return BadRequest(result.Message);

            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);
        }


        /*****************************************************************/
                                /*DELETE ARTWORK*/
        /*****************************************************************/

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id, long artistId)
        {
            var result = await _artworkService.DeleteAsync(id, artistId);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);
        }






    }
}
