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
    public class ClaimTicketController : ControllerBase
    {
        private readonly IClaimTicketService _claimTicketService;

        public ClaimTicketController(IClaimTicketService claimTicketService)
        {
            _claimTicketService = claimTicketService;
        }
    }
}
