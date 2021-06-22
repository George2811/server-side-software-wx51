using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.Domain.Models;
using PERUSTARS.Domain.Services;
using PERUSTARS.Domain.Services.Communications;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        /*****************************************************************/
                               /*LIST OF USERS*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "List all Users",
         Description = "List of all Users",
         OperationId = "ListAllUsers")]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<User>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }



        /*****************************************************************/
                              /*AUTHENTICATE USER*/
        /*****************************************************************/

        [SwaggerOperation(
          Summary = "Authenticate User",
          Description = "Authenticate User",
          OperationId = "AuthenticateUser")]
        [SwaggerResponse(200, "Authenticate User", typeof(AuthenticationResponse))]

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(AuthenticationResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            var response = await _userService.AuthenticateAsync(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }



        /*****************************************************************/
                              /*REGISTER USER*/
        /*****************************************************************/

        [SwaggerOperation(
          Summary = "Register User",
          Description = "Register User",
          OperationId = "RegisterUser")]
        [SwaggerResponse(200, "Register User", typeof(string))]

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            await _userService.RegisterAsync(request);
            return Ok(new { message = "Registration successful" });
        }
    }
}
