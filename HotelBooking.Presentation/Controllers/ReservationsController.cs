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

[ApiController]
[Authorize]
[Route("api/rooms/{roomId:guid}/reservations")]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class ReservationsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ReservationsController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of reservations
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="reservationParameters"></param>
    /// <returns>Reservations list</returns>
    /// <remarks>
    /// Query parameters MaxDateEntry and MaxDateExit should be greater than or equal to 
    /// MinDateEntry and MinDateExit accordingly, otherwise response code will by 400. <br />
    /// If the room with roomId does not exist, the response code will be 404. <br /> <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [ProducesResponseType(typeof(IEnumerable<ReservationDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetReservations(Guid roomId, [FromQuery] ReservationlParameters reservationParameters)
    {
        var (reservations, metaData) = await _service.ReservationService.GetReservationsAsync(roomId, reservationParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(reservations);
    }

    /// <summary>
    /// Gets a reservation
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <returns>Reservation</returns>
    /// <remarks>
    /// If the room with roomId or reservation with id does not exist, the response code will be 404.
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "ReservationById")]
    [ProducesResponseType(typeof(ReservationDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetReservation(Guid roomId, Guid id)
    {
        var reservation = await _service.ReservationService.GetReservationAsync(roomId, id);
        return Ok(reservation);
    }

    /// <summary>
    /// Creates a reservation
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="reservation"></param>
    /// <returns>A newly created reservation</returns>
    /// <remarks>
    /// You can find a href to the newly created reservation in the Location header. <br />
    /// If the room with roomId does not exist, the response code will be 404. <br />
    /// <i>You need to have an User role to perform this action. </i>
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [Authorize(Roles = "User")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReservationDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateReservation(Guid roomId, [FromBody] ReservationForCreationDto reservation)
    {
        var createdReservation = await _service.ReservationService.CreateReservationForRoomAsync(roomId, reservation);
        return CreatedAtRoute("ReservationById", new { roomId, id = createdReservation.Id }, createdReservation);
    }

    /// <summary>
    /// Updates a reservation
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <param name="reservation"></param>
    /// <returns>Updated reservation</returns>
    /// <remarks>
    /// If the room with roomId or reservation with id does not exist, the response code will be 404. <br />
    /// <i>You need to have an User or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "User, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReservationDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateReservation(Guid roomId, Guid id, 
        [FromBody] ReservationForUpdateDto reservation)
    {
        var updatedReservation = await _service.ReservationService.UpdateReservationForRoomAsync(roomId, id, reservation);
        return Ok(updatedReservation);
    }

    /// <summary>
    /// Partially updates a reservation
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated reservation</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/dateEntry",
    ///             "value": "2023-08-21T00:00:00"
    ///         }
    ///     ]
    /// Don't forget to add "Content-Type": "application/json-patch+json". <br />
    /// <i>You need to have an User or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "User, HotelOwner")]
    [Consumes("application/json-patch+json")]
    [ProducesResponseType(typeof(ReservationDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateReservation(Guid roomId, Guid id,
        [FromBody] JsonPatchDocument<ReservationForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (reservationToPatch, reservationEntity) = await _service.ReservationService.GetReservationForPatchAsync(roomId, id);
        patchDoc.ApplyTo(reservationToPatch);

        TryValidateModel(reservationToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedReservation = await _service.ReservationService.SaveChangesForPatchAsync(reservationToPatch, reservationEntity);
        return Ok(updatedReservation);
    }

    /// <summary>
    /// Deletes a reservation
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// <i>You need to have an User or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "User, HotelOwner")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteReservationForRoom(Guid roomId, Guid id)
    {
        await _service.ReservationService.DeleteReservationForRoomAsync(roomId, id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetReservationsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}