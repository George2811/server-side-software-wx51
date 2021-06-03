using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Services;
using PERUSTARS.Domain.Models;
using PERUSTARS.Resources;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using PERUSTARS.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PERUSTARS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        /*****************************************************************/
                               /*LIST OF ARTIST*/
        /*****************************************************************/


        [SwaggerOperation(
         Summary = "List all Artist",
         Description = "List of Artist",
         OperationId = "ListAllArtist")]
        [SwaggerResponse(200, "List of Artist", typeof(IEnumerable<ArtistResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtistResource>), 200)]
        public async Task<IEnumerable<ArtistResource>> GetAllAsync() {
            var artist = await _artistService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Artist>, IEnumerable<ArtistResource>>(artist);
            return resources;
        }

        /*****************************************************************/
                               /*GET ARTIST BY ID*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "Get artist by Id",
         Description = "Get artist by Id",
         OperationId = "GerArtistById")]
        [SwaggerResponse(200, "Get artist by id", typeof(ArtistResource))]

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id) {
            var result = await _artistService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource);
            return Ok(artistResource);
        }




        /*****************************************************************/
                              /*SAVE ARTIST*/
        /*****************************************************************/

        [SwaggerOperation(
          Summary = "Save Artist",
          Description = "Save Artist",
          OperationId = "SaveArtist")]
        [SwaggerResponse(200, "Save artist", typeof(ArtistResource))]

        [HttpPost]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveArtistResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var artist = _mapper.Map<SaveArtistResource, Artist>(resource);
            var result = await _artistService.SaveAsync(artist);

            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource);
            return Ok(artistResource);
        
        }


        /*****************************************************************/
                                  /*UPDATE ARTIST*/
        /*****************************************************************/

        [SwaggerOperation(
        Summary = "Update Artist",
        Description = "Update Artist",
        OperationId = "UpdateArtist")]
        [SwaggerResponse(200, "Update artist", typeof(ArtistResource))]


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveArtistResource resource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
           
            var artist = _mapper.Map<SaveArtistResource, Artist>(resource);
            var result = await _artistService.UpdateAsync(id, artist);

            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource);
            return Ok(artistResource);
        }



        /*****************************************************************/
                                 /*DELETE ARTIST*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Delete Artist",
           Description = "Delete Artist",
           OperationId = "DeleteArtist")]
        [SwaggerResponse(200, "Delete artist", typeof(ArtistResource))]

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id) {
            var result = await _artistService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource);
            return Ok(artistResource);
        }

       
    }
}
