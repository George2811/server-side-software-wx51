using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Extensions;
using PERUSTARS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClaimTicketsController : ControllerBase
    {
        private readonly IClaimTicketService _claimTicketService;
        private readonly IMapper _mapper;

        public ClaimTicketsController(IClaimTicketService claimTicketService, IMapper mapper)
        {
            _claimTicketService = claimTicketService;
            _mapper = mapper;
        }
        
        /*****************************************************************/
                               /*LIST OF CLAIM TICKETS*/
        /*****************************************************************/


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClaimTicketResource>), 200)]
        public async Task<IEnumerable<ClaimTicketResource>> GetAllAsync()
        {
            var claimTicket = await _claimTicketService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<ClaimTicket>, IEnumerable<ClaimTicketResource>>(claimTicket);
            return resources;
        }



        /*****************************************************************/
                                /*GET CLAIM TICKETS BY ID*/
        /*****************************************************************/

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClaimTicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _claimTicketService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var claimTicketResource = _mapper.Map<ClaimTicket, ClaimTicketResource>(result.Resource);
            return Ok(claimTicketResource);
        }





        /*****************************************************************/
                                /*SAVE CLAIM TICKET*/
        /*****************************************************************/


        [HttpPost]
        [ProducesResponseType(typeof(ClaimTicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveClaimTicketResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var claimTicket = _mapper.Map<SaveClaimTicketResource, ClaimTicket>(resource);
            var result = await _claimTicketService.SaveAsync(claimTicket);

            if (!result.Success)
                return BadRequest(result.Message);
            var claimTicketResource = _mapper.Map<ClaimTicket, ClaimTicketResource>(result.Resource);
            return Ok(claimTicketResource);

        }




        /*****************************************************************/
                                /*UPDATE CLAIM TICKET*/
        /*****************************************************************/


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClaimTicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveClaimTicketResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var claimTicket = _mapper.Map<SaveClaimTicketResource, ClaimTicket>(resource);
            var result = await _claimTicketService.UpdateAsync(id, claimTicket);

            if (!result.Success)
                return BadRequest(result.Message);

            var claimTicketResource = _mapper.Map<ClaimTicket, ClaimTicketResource>(result.Resource);
            return Ok(claimTicketResource);
        }


        /*****************************************************************/
                                /*DELETE CLAIM TICKET*/
        /*****************************************************************/

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClaimTicketResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _claimTicketService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var claimTicketResource = _mapper.Map<ClaimTicket, ClaimTicketResource>(result.Resource);
            return Ok(claimTicketResource);
        }

    }
}
