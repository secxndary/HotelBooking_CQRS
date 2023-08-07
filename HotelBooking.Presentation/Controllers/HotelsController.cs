using System.Text.Json;
using Application.Queries;
using Entities.ErrorModel;
using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Presentation.ModelBinders;
using MediatR;
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
[Route("api/hotels")]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class HotelsController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly ISender _sender;

    public HotelsController(IServiceManager service, ISender sender)
    {
        _service = service;
        _sender = sender;
    }


    [HttpGet("CQRS", Name = "GetHotelsCQRS")]
    public async Task<IActionResult> GetHotelsCQRS()
    {
        var hotels = await _sender.Send(new GetHotelsQuery(TrackChanges: false));
        return Ok(hotels);
    }

    [HttpGet("CQRS/{id:guid}", Name = "HotelByIdCQRS")]
    public async Task<IActionResult> GetHotelCQRS(Guid id)
    {
        var hotel = await _sender.Send(new GetHotelQuery(id, TrackChanges: false));
        return Ok(hotel);
    }

    /// <summary>
    /// Gets the list of all hotels
    /// </summary>
    /// <param name="hotelParameters"></param>
    /// <returns>Hotels list</returns>
    /// <remarks>
    /// Query parameter MaxStars should be greater than or equal 
    /// to MinStars, otherwise response code will by 400. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    [HttpGet(Name = "GetHotels")]
    [HttpHead]
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    public async Task<IActionResult> GetHotels([FromQuery] HotelParameters hotelParameters)
    {
        var (hotels, metadata) = await _service.HotelService.GetAllHotelsAsync(hotelParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
        return Ok(hotels);
    }

    /// <summary>
    /// Gets a hotel collection
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Hotels list</returns>
    /// <remarks>
    /// Please note that required query parameter "ids" should look like 
    /// (f934d940-f542-400b-8182-aea42a9b0773, 0c6cc6d4-3f8c-43d2-9591-230cb646aab9) <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If parameters are invalid</response>
    [HttpGet("collection/({ids})", Name = "HotelCollection")]
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    public async Task<IActionResult> GetHotelCollection(
        [FromRoute] 
        [ModelBinder(typeof(ArrayModelBinder))] 
        IEnumerable<Guid> ids)
    {
        var hotels = await _service.HotelService.GetByIdsAsync(ids);
        return Ok(hotels);
    }

    /// <summary>
    /// Gets a hotel
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Hotel</returns>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "HotelById")]
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetHotel(Guid id)
    {
        var hotel = await _service.HotelService.GetHotelAsync(id);
        return Ok(hotel);
    }

    /// <summary>
    /// Creates a hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns>A newly created hotel</returns>
    /// <remarks>
    /// You can create rooms for a newly created hotel in one request by adding "rooms" array to the request body. <br />
    /// However, only the newly created hotel will be returned in response. <br />
    /// You can also find a href to the newly created hotel in the Location header. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action. </i>
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost(Name = "CreateHotel")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(HotelDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateHotel([FromBody] HotelForCreationDto hotel)
    {
        var createdHotel = await _service.HotelService.CreateHotelAsync(hotel);
        return CreatedAtRoute("HotelById", new { id = createdHotel.Id }, createdHotel);
    }

    /// <summary>
    /// Creates a hotel collection
    /// </summary>
    /// <param name="hotelCollection"></param>
    /// <returns>A newly created hotel collection</returns>
    /// <remarks>
    /// You can find a href to the newly created hotel collection in the Location header. <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the newly created list of items</response>
    /// <response code="400">If the collection or ids are null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("collection")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateHotelCollection([FromBody] IEnumerable<HotelForCreationDto> hotelCollection)
    {
        var (hotels, ids) = await _service.HotelService.CreateHotelCollectionAsync(hotelCollection);
        return CreatedAtRoute("HotelCollection", new { ids }, hotels);
    }

    /// <summary>
    /// Updates a hotel
    /// </summary>
    /// <param name="id"></param>
    /// <param name="hotel"></param>
    /// <returns>Updated hotel</returns>
    /// <remarks>
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelForUpdateDto hotel)
    {
        var updatedHotel = await _service.HotelService.UpdateHotelAsync(id, hotel);
        return Ok(updatedHotel);
    }

    /// <summary>
    /// Partially updates a hotel
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated hotel</returns>
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
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [Consumes("application/json-patch+json")]
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateHotel(Guid id, [FromBody] JsonPatchDocument<HotelForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelToPatch, hotelEntity) = await _service.HotelService.GetHotelForPatchAsync(id);
        patchDoc.ApplyTo(hotelToPatch);

        TryValidateModel(hotelToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedHotel = await _service.HotelService.SaveChangesForPatchAsync(hotelToPatch, hotelEntity);
        return Ok(updatedHotel);
    }

    /// <summary>
    /// Deletes a hotel
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteHotel(Guid id)
    {
        await _service.HotelService.DeleteHotelAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetHotelsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}