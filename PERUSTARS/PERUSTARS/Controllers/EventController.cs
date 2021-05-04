using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper; 
        }


        /*****************************************************************/
                              /*LIST OF EVENTS*/
        /*****************************************************************/

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventResource>), 200)]
        public async Task<IEnumerable<EventResource>> GetAllAsync()
        {
            var _event = await _eventService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Event>, IEnumerable<EventResource>>(_event);
            return resources;
        }


        /*****************************************************************/
                             /*GET EVENTS BY ID*/
        /*****************************************************************/

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _eventService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }



        /*****************************************************************/
                               /*SAVE EVENTS BY ID*/
        /*****************************************************************/


        [HttpPost]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var _event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.SaveAsync(_event);

            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }





        /*****************************************************************/
                               /*Update EVENTS */
        /*****************************************************************/




        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var _event = _mapper.Map<SaveEventResource, Event>(resource);
            var result = await _eventService.UpdateAsync(id, _event);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }

        /*****************************************************************/
                                /*DELETE EVENTS */
        /*****************************************************************/


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _eventService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }
    }
}
