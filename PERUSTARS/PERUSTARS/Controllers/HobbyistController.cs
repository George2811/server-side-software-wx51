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
    public class HobbyistsController : ControllerBase
    {
        private readonly IHobbyistService _hobbyistService;
        private readonly IMapper _mapper;

        public HobbyistsController(IHobbyistService hobbyistService, IMapper mapper)
        {
            _hobbyistService = hobbyistService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "List all Hobbyists",
        Description = "List of Hobbyist",
        OperationId = "ListAllHobbyists")]
        [SwaggerResponse(200, "List of Hobbyists", typeof(IEnumerable<HobbyistResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HobbyistResource>), 200)]
        public async Task<IEnumerable<HobbyistResource>> GetAllAsync()
        {
            var hobbyists = await _hobbyistService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Hobbyist>, IEnumerable<HobbyistResource>>(hobbyists);
            return resources;
        }


        [SwaggerOperation(
        Summary = "Get hobbyist by Id",
        Description = "Get hobbyist by Id",
        OperationId = "GetHobbyistById")]
        [SwaggerResponse(200, "Get hobbyist by id", typeof(HobbyistResource))]

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HobbyistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _hobbyistService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(result.Resource);
            return Ok(hobbyistResource);
        }


        [SwaggerOperation(
          Summary = "Save Hobbyist",
          Description = "Save Hobbyist",
          OperationId = "SaveHobbyist")]
        [SwaggerResponse(200, "Save hobbyist", typeof(HobbyistResource))]

        [HttpPost]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveHobbyistResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var hobbyist = _mapper.Map<SaveHobbyistResource, Hobbyist>(resource);
            var result = await _hobbyistService.SaveAsync(hobbyist);

            if (!result.Success)
                return BadRequest(result.Message);
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(result.Resource);
            return Ok(hobbyistResource);
        }


        [SwaggerOperation(
        Summary = "Update Hobbyist",
        Description = "Update Hobbyist",
        OperationId = "UpdateHobbyist")]
        [SwaggerResponse(200, "Update hobbyist", typeof(HobbyistResource))]

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(HobbyistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveHobbyistResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var hobbyist = _mapper.Map<SaveHobbyistResource, Hobbyist>(resource);
            var result = await _hobbyistService.UpdateAsync(id, hobbyist);

            if (!result.Success)
                return BadRequest(result.Message);

            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(result.Resource);
            return Ok(hobbyistResource);
        }


        [SwaggerOperation(
           Summary = "Delete Hobbyist",
           Description = "Delete Hobbyist",
           OperationId = "DeleteHobbyist")]
        [SwaggerResponse(200, "Delete hobbyist", typeof(HobbyistResource))]

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(HobbyistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _hobbyistService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(result.Resource);
            return Ok(hobbyistResource);
        }

    }
}

