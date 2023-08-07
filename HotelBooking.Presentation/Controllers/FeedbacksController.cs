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
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class FeedbacksController : ControllerBase
{
    private readonly IServiceManager _service;
    public FeedbacksController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of feedbacks by hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [Route("api/hotels/{hotelId:guid}/feedbacks")]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetFeedbacksForHotel(Guid hotelId, [FromQuery] FeedbackParameters feedbackParameters)
    {
        var (feedbacks, metaData) = await _service.FeedbackService.GetFeedbacksForHotelAsync(hotelId, feedbackParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(feedbacks);
    }

    /// <summary>
    /// Gets the list of feedbacks by room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [Route("api/rooms/{roomId:guid}/feedbacks")]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetFeedbacksForRoom(Guid roomId, [FromQuery] FeedbackParameters feedbackParameters)
    {
        var (feedbacks, metaData) = await _service.FeedbackService.GetFeedbacksForRoomAsync(roomId, feedbackParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(feedbacks);
    }

    /// <summary>
    /// Gets the list of feedbacks by reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the resertvation with reservationId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetFeedbacksForReservation(Guid reservationId, [FromQuery] FeedbackParameters feedbackParameters)
    {
        var (feedbacks, metaData) = await _service.FeedbackService.GetFeedbacksForReservationAsync(reservationId, feedbackParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(feedbacks);
    }

    /// <summary>
    /// Gets a feedback
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Feedback</returns>
    /// <remarks>
    /// If the feedback with id or does not exist, the response code will be 404.
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [Route("api/feedbacks/{id:guid}", Name = "FeedbackById")]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetFeedback(Guid id)
    {
        var feedback = await _service.FeedbackService.GetFeedbackAsync(id);
        return Ok(feedback);
    }


    /// <summary>
    /// Creates a feedback
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns>A newly created feedback</returns>
    /// <remarks>
    /// You can find a href to the newly created feedback in the Location header. <br />
    /// <i>You need to have an User role to perform this action. </i>
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [Authorize(Roles = "User")]
    [Route("api/feedbacks", Name = "CreateFeedback")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(FeedbackDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackForCreationDto feedback)
    {
        var createdFeedback = await _service.FeedbackService.CreateFeedbackAsync(feedback);
        return CreatedAtRoute("FeedbackById", new { id = createdFeedback.Id }, createdFeedback);
    }

    /// <summary>
    /// Updates a feedback
    /// </summary>
    /// <param name="id"></param>
    /// <param name="feedback"></param>
    /// <returns>Updated feedback</returns>
    /// <remarks>
    /// If the feedback with id does not exist, the response code will be 404. <br />
    /// <i>You need to have an User role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("api/feedbacks/{id:guid}")]
    [Authorize(Roles = "User")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateFeedback(Guid id, [FromBody] FeedbackForUpdateDto feedback)
    {
        var updatedFeedback = await _service.FeedbackService.UpdateFeedbackAsync(id, feedback);
        return Ok(updatedFeedback);
    }

    /// <summary>
    /// Partially updates a feedback
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated feedback</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/textPositive",
    ///             "value": "sample text"
    ///         }
    ///     ]
    /// Don't forget to add "Content-Type": "application/json-patch+json". <br />
    /// <i>You need to have an User role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPatch("api/feedbacks/{id:guid}")]
    [Authorize(Roles = "User")]
    [Consumes("application/json-patch+json")]
    [ProducesResponseType(typeof(FeedbackDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateFeedback(Guid id, 
        [FromBody] JsonPatchDocument<FeedbackForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (feedbackToPatch, feedbackEntity) = await _service.FeedbackService.GetFeedbackForPatchAsync(id);
        patchDoc.ApplyTo(feedbackToPatch);

        TryValidateModel(feedbackToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedFeedback = await _service.FeedbackService.SaveChangesForPatchAsync(feedbackToPatch, feedbackEntity);
        return Ok(updatedFeedback);
    }

    /// <summary>
    /// Deletes a feedback
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// <i>You need to have an User or Admin role to perform this action.</i>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("api/feedbacks/{id:guid}")]
    [Authorize(Roles = "User, Admin")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteFeedback(Guid id)
    {
        await _service.FeedbackService.DeleteFeedbackAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions("api/feedbacks")]
    [ProducesResponseType(204)]
    public IActionResult GetFeedbacksOptions()
    {
        Response.Headers.Add("Allow", "OPTIONS, POST");
        return Ok();
    }
}