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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
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
        [ProducesResponseType(typeof(IEnumerable<ArtworkResource>), 200)]
        public async Task<IEnumerable<ArtworkResource>> GetAllAsync()
        {
            var artwork = await _artworkService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Artwork>, IEnumerable<ArtworkResource>>(artwork);
            return resources;
        }



        /*****************************************************************/
                                /*GET ARTWORKS BY ID*/
        /*****************************************************************/

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _artworkService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);
        }




        /*****************************************************************/
                                /*UPDATE ARTWORK*/
        /*****************************************************************/


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveArtworkResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var artwork = _mapper.Map<SaveArtworkResource, Artwork>(resource);
            var result = await _artworkService.UpdateAsync(id, artwork);

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
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _artworkService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork, ArtworkResource>(result.Resource);
            return Ok(artworkResource);
        }






    }
}
