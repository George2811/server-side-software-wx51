using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("/api/hobbyists/{hobbyistId}/follows")]
    [Produces("application/json")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IHobbyistService _hobbyistService;
        private readonly IMapper _mapper;

        public FollowsController(IHobbyistService hobbyistService, IMapper mapper)
        {
            _hobbyistService = hobbyistService;
            _mapper = mapper;
        }


        [SwaggerOperation(
           Summary = "Get All Hobbyist By Artist Id",
           Description = "Get All Hobbyists By Artist Id",
           OperationId = "GetAllByArtistId")]
        [SwaggerResponse(200, "Get All By HobbyistId", typeof(HobbyistResource))]

        [ProducesResponseType(typeof(HobbyistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]

        [HttpGet]
        public async Task<IEnumerable<HobbyistResource>> GetAllByArtistIdAsync(int artistId)
        {
            var hobbyists = await _hobbyistService.ListByArtistIdAsync(artistId);
            var resources = _mapper.Map<IEnumerable<Hobbyist>, IEnumerable<HobbyistResource>>(hobbyists);
            return resources;
        }
    }
}
