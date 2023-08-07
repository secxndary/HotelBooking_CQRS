using Entities.ErrorModel;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace HotelBooking.Presentation.Controllers.Authentication;

[ApiController]
[Route("api/token")]
[Consumes("application/json")]
[Produces("application/json")]
public class TokenController : ControllerBase
{
    private readonly IServiceManager _service;
    public TokenController(IServiceManager service) => _service = service;


    /// <summary>
    /// Refreshes tokens
    /// </summary>
    /// <param name="tokenDto"></param>
    /// <returns>TokenDto</returns>
    /// <remarks>
    /// This endpoint is used for token refreshing. <br />
    /// If you send access and refresh token via request body, you'll get a new pair of access and refresh tokens. <br />
    /// The tokens you sent will become expired an inaccessible. <br />
    /// Also, you don't have to send Authorization header to this endpoint. <br />
    /// If the refresh token is incorrect or already expired, the response code will be 400. <br />
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="400">If the token is invalid</response>
    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(TokenDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoRefreshed = await _service.AuthenticationService.RefreshToken(tokenDto);
        return Ok(tokenDtoRefreshed);
    }
}
