using System.Text.Json;
using Entities.ErrorModel;
using Entities.LinkModels;
using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api/hotels/{hotelId:guid}/rooms")]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class RoomsController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomsController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of rooms
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomParameters"></param>
    /// <returns>Rooms list</returns>
    /// <remarks>
    /// Query parameters MaxSleepingPlaces and MaxPrice should be greater than or equal to 
    /// MinSleepingPlaces and MinPrice accordingly, otherwise response code will by 400. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br /> <br />
    /// <strong>Data Shaping support:</strong> <br />
    /// Enumerate the desirable comma-separated fields in the query parameter "fields" (e.g. fields=id,name,price). <br />
    /// <br />
    /// <strong>HATEOAS support:</strong> <br />
    /// Add one of the options to the "Accept" header: <br />
    /// (<b>WARN:</b> You can't add Accept header for this action in Swagger because it doesn't have request body) <br />
    /// • JSON: "application/vnd.hotelbooking.hateoas+json" <br />
    /// • XML: "application/vnd.hotelbooking.hateoas+xml" <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Consumes("application/vnd.hotelbooking.hateoas+json", "application/vnd.hotelbooking.hateoas+xml")]
    [Produces("application/vnd.hotelbooking.hateoas+json", "application/vnd.hotelbooking.hateoas+xml")]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomsForHotel(Guid hotelId, [FromQuery] RoomParameters roomParameters)
    {
        var linkParameters = new LinkParameters(roomParameters, HttpContext);
        var (linkResponse, metaData) = await _service.RoomService.GetRoomsAsync(hotelId, linkParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return linkResponse.HasLinks ? Ok(linkResponse.LinkedEntities) : Ok(linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets a room collection
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="ids"></param>
    /// <returns>Rooms list</returns>
    /// <remarks>
    /// Please note that required query parameter "ids" should look like 
    /// (f934d940-f542-400b-8182-aea42a9b0773, 0c6cc6d4-3f8c-43d2-9591-230cb646aab9) <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the hotel with hotelId or room with id does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("collection/({ids})", Name = "RoomCollection")]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomCollection(Guid hotelId,
        [FromRoute]
        [ModelBinder(typeof(ArrayModelBinder))] 
        IEnumerable<Guid> ids)
    {
        var rooms = await _service.RoomService.GetByIdsForHotelAsync(hotelId, ids);
        return Ok(rooms);
    }

    /// <summary>
    /// Gets a room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <returns>Room</returns>
    /// <remarks>
    /// If the hotel with hotelId or room with id does not exist, the response code will be 404.
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "GetRoomForHotel")]
    [ProducesResponseType(typeof(RoomDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomForHotel(Guid hotelId, Guid id)
    {
        var room = await _service.RoomService.GetRoomAsync(hotelId, id);
        return Ok(room);
    }

    /// <summary>
    /// Creates a room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="room"></param>
    /// <returns>A newly created room</returns>
    /// <remarks>
    /// You can find a href to the newly created room in the Location header. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action. </i>
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateRoom(Guid hotelId, [FromBody] RoomForCreationDto room)
    {
        var createdRoom = await _service.RoomService.CreateRoomForHotelAsync(hotelId, room);
        return CreatedAtRoute("GetRoomForHotel", new { hotelId, id = createdRoom.Id }, createdRoom);
    }

    /// <summary>
    /// Creates a room collection
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomCollection"></param>
    /// <returns>A newly created room collection</returns>
    /// <remarks>
    /// You can find a href to the newly created room collection in the Location header. <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the newly created list of items</response>
    /// <response code="400">If the collection or ids are null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("collection")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ProducesResponseType(typeof(IEnumerable<RoomDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateRoomCollection(Guid hotelId, [FromBody] IEnumerable<RoomForCreationDto> roomCollection)
    {
        var (rooms, ids) = await _service.RoomService.CreateRoomCollectionAsync(hotelId, roomCollection);
        return CreatedAtRoute("RoomCollection", new { hotelId, ids }, rooms);
    }

    /// <summary>
    /// Updates a room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <param name="room"></param>
    /// <returns>Updated room</returns>
    /// <remarks>
    /// If the hotel with hotelId or room with id does not exist, the response code will be 404. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateRoomForHotel(Guid hotelId, Guid id, [FromBody] RoomForUpdateDto room)
    {
        var updatedRoom = await _service.RoomService.UpdateRoomForHotelAsync(hotelId, id, room);
        return Ok(updatedRoom);
    }

    /// <summary>
    /// Partially updates a room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated room</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/price",
    ///             "value": 420
    ///         }
    ///     ]
    /// Don't forget to add "Content-Type": "application/json-patch+json". <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [Consumes("application/json-patch+json")]
    [ProducesResponseType(typeof(RoomDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateRoomForHotel(Guid hotelId, Guid id, 
        [FromBody] JsonPatchDocument<RoomForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomToPatch, roomEntity) = await _service.RoomService.GetRoomForPatchAsync(hotelId, id);
        patchDoc.ApplyTo(roomToPatch, ModelState);

        TryValidateModel(roomToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRoom = await _service.RoomService.SaveChangesForPatchAsync(roomToPatch, roomEntity);
        return Ok(updatedRoom);
    }

    /// <summary>
    /// Deletes a room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// <i>You need to have a HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "HotelOwner")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteRoomForHotel(Guid hotelId, Guid id)
    {
        await _service.RoomService.DeleteRoomForHotelAsync(hotelId, id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetRoomsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}