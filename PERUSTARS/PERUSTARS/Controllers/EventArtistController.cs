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
    [Route("/api/artist/{artistId}/events")]
    public class EventArtistController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventArtistController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }



        /*****************************************************************/
                     /*GET EVENTS BY ID*/
        /*****************************************************************/
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _eventService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }



        /*****************************************************************/
                           /*SAVE EVENTS/
        /*****************************************************************/


        [HttpPost]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEventResource resource, long artistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var _event = _mapper.Map<SaveEventResource, Event>(resource);
            _event.ArtistId = artistId;
            var result = await _eventService.SaveAsync(_event);

            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }



    }
}
