using System.Text.Json;
using Entities.ErrorModel;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roomTypes")]
[ApiController]
[Authorize]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class RoomTypesController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomTypesController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of all room types
    /// </summary>
    /// <param name="roomTypeParameters"></param>
    /// <returns>RoomTypes list</returns>
    /// <response code="200">Returns list of items</response>
    [HttpGet(Name = "GetRoomTypes")]
    [HttpHead]
    [ProducesResponseType(typeof(IEnumerable<RoomTypeDto>), 200)]
    public async Task<IActionResult> GetRoomTypes([FromQuery] RoomTypeParameters roomTypeParameters)
    {
        var (roomTypes, metaData) = await _service.RoomTypeService.GetAllRoomTypesAsync(roomTypeParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(roomTypes);
    }

    /// <summary>
    /// Gets a room type
    /// </summary>
    /// <param name="id"></param>
    /// <returns>RoomType</returns>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "RoomTypeById")]
    [ProducesResponseType(typeof(RoomTypeDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetRoomType(Guid id)
    {
        var roomType = await _service.RoomTypeService.GetRoomTypeAsync(id);
        return Ok(roomType);
    }

    /// <summary>
    /// Creates a room type
    /// </summary>
    /// <param name="roomType"></param>
    /// <returns>A newly created RoomType</returns>
    /// <remarks>
    /// You can find a href to the newly created room type in the Location header. <br />
    /// <i>You need to have an Admin role to perform this action. </i>
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost(Name = "CreateRoomType")]
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomTypeDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateRoomType([FromBody] RoomTypeForCreationDto roomType)
    {
        var createdRoomType = await _service.RoomTypeService.CreateRoomTypeAsync(roomType);
        return CreatedAtRoute("RoomTypeById", new { id = createdRoomType.Id }, createdRoomType);
    }

    /// <summary>
    /// Updates a room type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="roomType"></param>
    /// <returns>Updated RoomType</returns>
    /// <remarks>
    /// <i>You need to have an Admin role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(RoomTypeDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateRoomType(Guid id, [FromBody] RoomTypeForUpdateDto roomType)
    {
        var updatedRoomType = await _service.RoomTypeService.UpdateRoomTypeAsync(id, roomType);
        return Ok(updatedRoomType);
    }

    /// <summary>
    /// Partially updates a room type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated roomType</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/name",
    ///             "value": "New name"
    ///         }
    ///     ]
    /// Don't forget to add "Content-Type": "application/json-patch+json". <br />
    /// <i>You need to have an Admin role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json-patch+json")]
    [ProducesResponseType(typeof(RoomTypeDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateRoomType(Guid id, [FromBody] JsonPatchDocument<RoomTypeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomTypeToPatch, roomTypeEntity) = await _service.RoomTypeService.GetRoomTypeForPatchAsync(id);
        patchDoc.ApplyTo(roomTypeToPatch);

        TryValidateModel(roomTypeToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRoomType = await _service.RoomTypeService.SaveChangesForPatchAsync(roomTypeToPatch, roomTypeEntity);
        return Ok(updatedRoomType);
    }

    /// <summary>
    /// Deletes a room type
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// <i>You need to have an Admin role to perform this action.</i>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteRoomType(Guid id)
    {
        await _service.RoomTypeService.DeleteRoomTypeAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetRoomTypesOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}