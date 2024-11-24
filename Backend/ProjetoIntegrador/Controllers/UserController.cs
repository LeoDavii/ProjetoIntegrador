using Microsoft.AspNetCore.Mvc;
using Source.Dtos;
using Source.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : Controller
    {
        /// <summary>
        ///     Login
        /// </summary>
        /// <returns>Response Data</returns>
        /// <response code="200">The request was accepted, returns user and token.</response>
        /// <response code="400">The request was unsuccessful.</response>
        [HttpPatch]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(UserLoginResponseDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public ActionResult Login([FromBody] UserRequestDto request) 
        {
            try
            {
                return Ok(userService.Login(request));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
