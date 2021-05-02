using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artowrkService;

        public ArtworkController(IArtworkService artowrkService)
        {
            _artowrkService = artowrkService;
        }
    }
}
