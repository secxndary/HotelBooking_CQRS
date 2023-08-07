using System.Text.Json;
using Entities.ErrorModel;
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
[Route("api/rooms/{roomId:guid}/photos")]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class RoomPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomPhotosController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of room photos
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomPhotoParameters"></param>
    /// <returns>RoomPhotos list</returns>
    /// <remarks>
    /// If the room with roomId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [ProducesResponseType(typeof(IEnumerable<RoomPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomPhotos(Guid roomId, [FromQuery] RoomPhotoParameters roomPhotoParameters)
    {
        var (roomPhotos, metaData) = await _service.RoomPhotoService.GetRoomPhotosAsync(roomId, roomPhotoParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(roomPhotos);
    }

    /// <summary>
    /// Gets a room photo collection
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="ids"></param>
    /// <returns>RoomPhotos list</returns>
    /// <remarks>
    /// Please note that required query parameter "ids" should look like 
    /// (f934d940-f542-400b-8182-aea42a9b0773, 0c6cc6d4-3f8c-43d2-9591-230cb646aab9) <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the room with roomId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("collection/({ids})", Name = "RoomPhotoCollection")]
    [ProducesResponseType(typeof(IEnumerable<RoomPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomPhotoCollection(Guid roomId,
        [FromRoute]
        [ModelBinder(typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        var roomPhotos = await _service.RoomPhotoService.GetByIdsAsync(roomId, ids);
        return Ok(roomPhotos);
    }

    /// <summary>
    /// Gets a room photo
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <returns>Room</returns>
    /// <remarks>
    /// If the room with roomId or room photo with id does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "GetRoomPhotoForRoom")]
    [ProducesResponseType(typeof(RoomPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomPhoto(Guid roomId, Guid id)
    {
        var roomPhoto = await _service.RoomPhotoService.GetRoomPhotoAsync(roomId, id);
        return Ok(roomPhoto);
    }

    /// <summary>
    /// Creates a room photo
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomPhoto"></param>
    /// <returns>A newly created room photo</returns>
    /// <remarks>
    /// You can find a href to the newly created room photo in the Location header. <br />
    /// If the room with roomId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomPhotoDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateRoomPhoto(Guid roomId, [FromBody] RoomPhotoForCreationDto roomPhoto)
    {
        var createdRoomPhoto = await _service.RoomPhotoService.CreateRoomPhotoAsync(roomId, roomPhoto);
        return CreatedAtRoute("GetRoomPhotoForRoom", new { roomId, id = createdRoomPhoto.Id }, createdRoomPhoto);
    }

    /// <summary>
    /// Creates a room photo collection
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomPhotoCollection"></param>
    /// <returns>A newly created room photo collection</returns>
    /// <remarks>
    /// You can find a href to the newly created room photo collection in the Location header. <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the room with roomId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns the newly created list of items</response>
    /// <response code="400">If the collection or ids are null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("collection")]
    [ProducesResponseType(typeof(IEnumerable<RoomPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateRoomPhotoCollection(Guid roomId, 
        [FromBody] IEnumerable<RoomPhotoForCreationDto> roomPhotoCollection)
    {
        var (roomPhotos, ids) = await _service.RoomPhotoService.CreateRoomPhotoCollectionAsync(roomId, roomPhotoCollection);
        return CreatedAtRoute("RoomPhotoCollection", new { roomId, ids }, roomPhotos);
    }

    /// <summary>
    /// Updates a room photo
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <param name="roomPhoto"></param>
    /// <returns>Updated room photo</returns>
    /// <remarks>
    /// If the room with roomId or room photo with id does not exist, the response code will be 404. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateRoomPhoto(Guid roomId, Guid id, [FromBody] RoomPhotoForUpdateDto roomPhoto)
    {
        var updatedRoomPhoto = await _service.RoomPhotoService.UpdateRoomPhotoAsync(roomId, id, roomPhoto);
        return Ok(updatedRoomPhoto);
    }

    /// <summary>
    /// Partially updates a room photo
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated room photo</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/path",
    ///             "value": "../../../Content/Images/Rooms/new-room-photo.jpeg"
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
    [ProducesResponseType(typeof(RoomPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateRoomPhoto(Guid roomId, Guid id,
        [FromBody] JsonPatchDocument<RoomPhotoForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomPhotoToPatch, roomPhotoEntity) = await _service.RoomPhotoService.GetRoomPhotoForPatchAsync(roomId, id);
        patchDoc.ApplyTo(roomPhotoToPatch);

        TryValidateModel(roomPhotoToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRoomPhoto = await _service.RoomPhotoService.SaveChangesForPatchAsync(roomPhotoToPatch, roomPhotoEntity);
        return Ok(updatedRoomPhoto);
    }

    /// <summary>
    /// Deletes a room photo
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteRoomPhoto(Guid roomId, Guid id)
    {
        await _service.RoomPhotoService.DeleteRoomPhotoAsync(roomId, id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetRoomPhotosOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}