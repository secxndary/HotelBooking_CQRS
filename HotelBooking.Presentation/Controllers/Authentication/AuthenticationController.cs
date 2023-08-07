using Entities.ErrorModel;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace HotelBooking.Presentation.Controllers.Authentication;

[ApiController]
[Route("api/authentication")]
[Consumes("application/json")]
[Produces("application/json")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service) => _service = service;


    /// <summary>
    /// Registers the user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Created</returns>
    /// <remarks>
    /// <strong>In the "roles" array, add one or many roles: </strong><br />
    /// • User <br />
    /// • Admin <br />
    /// • HotelOwner <br />
    /// <br />
    /// <strong>Requirements for the password:</strong><br />
    /// • Digit <br />
    /// • Uppercase letter <br />
    /// • Lowercase letter <br />
    /// • NonAlphanumeric symbol <br />
    /// • At least 10 symbols <br />
    /// • Email should be unique <br />
    /// • Username should be unique <br />
    /// </remarks>
    /// <response code="201">If the item is created</response>
    /// <response code="400">If the item is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(201)]
    [ProducesResponseType(typeof(IdentityError), 400)]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto user)
    {
        var result = await _service.AuthenticationService.RegisterUser(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);
            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    /// <summary>
    /// Logs in to user account
    /// </summary>
    /// <param name="user"></param>
    /// <returns>TokenDto</returns>
    /// <remarks>
    /// This method is used for user authentication. <br />
    /// If you send user credentials (username and password), you'll get access and refresh tokens. <br />
    /// If credentials are incorrect or null, the response status will be 401. <br />
    /// </remarks>
    /// <response code="200">If the credentials are correct</response>
    /// <response code="401">If the credentials are incorrect</response>
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(TokenDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 401)]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();

        var tokenDto = await _service.AuthenticationService.CreateToken(populateExpiration: true);
        return Ok(tokenDto);
    }
}