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
    public class FavoriteArtworksController : ControllerBase
    {
        private readonly IFavoriteArtworkService _favoriteArtworkService;

        public FavoriteArtworksController(IFavoriteArtworkService favoriteArtworkService)
        {
            _favoriteArtworkService = favoriteArtworkService;
        }
    }
}
