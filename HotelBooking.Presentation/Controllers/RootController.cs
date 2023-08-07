using Entities.LinkModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
namespace HotelBooking.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api")]
[Consumes("application/vnd.hotelbooking.apiroot+json", "application/vnd.hotelbooking.apiroot+xml")]
[Produces("application/vnd.hotelbooking.apiroot+json", "application/vnd.hotelbooking.apiroot+xml")]
public class RootController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;
    public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;


    /// <summary>
    /// Gets API root
    /// </summary>
    /// <param name="mediaType"></param>
    /// <returns>List of links</returns>
    /// <remarks>
    /// <strong>Important: Don't forget to add one of the options to the "Accept" header: </strong><br />
    /// (<b>WARN:</b> You can't add Accept header for this action in Swagger because it doesn't have request body) <br />
    /// • JSON: "application/vnd.hotelbooking.apiroot+json" <br />
    /// • XML: "application/vnd.hotelbooking.apiroot+xml" <br />
    /// <br />
    /// This endpoint shows available actions at the API root level (/api/). <br />
    /// It returns a list of links, that looks like this:
    /// 
    /// [
    ///     {
    ///         "href": "/api",
    ///         "rel": "self",
    ///         "method": "GET"
    ///     },
    ///     {
    ///         "href": "/api/hotels",
    ///         "rel": "hotels",
    ///         "method": "GET"
    ///     },
    ///     {
    ///         "href": "/api/hotels",
    ///         "rel": "create_hotel",
    ///         "method": "POST"
    ///     },
    ///     ...
    /// ]
    /// </remarks>
    [HttpGet(Name = "GetRoot")]
    [ProducesResponseType(200)]
    public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
    {
        if (!mediaType.Contains("application/vnd.hotelbooking.apiroot"))
            return NoContent();

        var links = new List<Link>
            {
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new { }),
                    Rel = "self",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetHotels", new { }),
                    Rel = "hotels",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateHotel", new { }),
                    Rel = "create_hotel",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetRoles", new { }),
                    Rel = "roles",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateRole", new { }),
                    Rel = "create_role",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetUsers", new { }),
                    Rel = "users",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateUser", new { }),
                    Rel = "create_user",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetRoomTypes", new { }),
                    Rel = "roomTypes",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateRoomType", new { }),
                    Rel = "create_roomType",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateFeedback", new { }),
                    Rel = "create_feedback",
                    Method = "POST"
                }
            };

        return Ok(links);
    }
}