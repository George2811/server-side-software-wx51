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
    public class HobbyistController : ControllerBase
    {
        private readonly IHobbyistService _hobbyistService;

        public HobbyistController(IHobbyistService hobbyistService)
        {
            _hobbyistService = hobbyistService;
        }
    }
}
