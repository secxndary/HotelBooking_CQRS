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
[Route("api/hotels/{hotelId:guid}/photos")]
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class HotelPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelPhotosController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of hotel photos
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="hotelPhotoParameters"></param>
    /// <returns>HotelPhotos list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [ProducesResponseType(typeof(IEnumerable<HotelPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetHotelPhotos(Guid hotelId, [FromQuery] HotelPhotoParameters hotelPhotoParameters)
    {
        var (hotelPhotos, metaData) = await _service.HotelPhotoService.GetHotelPhotosAsync(hotelId, hotelPhotoParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(hotelPhotos);
    }

    /// <summary>
    /// Gets a hotel photo collection
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="ids"></param>
    /// <returns>HotelPhotos list</returns>
    /// <remarks>
    /// Please note that required query parameter "ids" should look like 
    /// (f934d940-f542-400b-8182-aea42a9b0773, 0c6cc6d4-3f8c-43d2-9591-230cb646aab9) <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("collection/({ids})", Name = "HotelPhotoCollection")]
    [ProducesResponseType(typeof(IEnumerable<HotelPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetHotelPhotoCollection(Guid hotelId,
        [FromRoute]
        [ModelBinder(typeof(ArrayModelBinder))] 
        IEnumerable<Guid> ids)
    {
        var hotelPhotos = await _service.HotelPhotoService.GetByIdsAsync(hotelId, ids);
        return Ok(hotelPhotos);
    }

    /// <summary>
    /// Gets a hotel photo
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <returns>Hotel</returns>
    /// <remarks>
    /// If the hotel with hotelId or hotel photo with id does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns item</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet("{id:guid}", Name = "GetHotelPhotoForHotel")]
    [ProducesResponseType(typeof(HotelPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> GetHotelPhoto(Guid hotelId, Guid id)
    {
        var hotelPhoto = await _service.HotelPhotoService.GetHotelPhotoAsync(hotelId, id);
        return Ok(hotelPhoto);
    }

    /// <summary>
    /// Creates a hotel photo
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="hotelPhoto"></param>
    /// <returns>A newly created hotel photo</returns>
    /// <remarks>
    /// You can find a href to the newly created hotel photo in the Location header. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(HotelPhotoDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateHotelPhoto(Guid hotelId, [FromBody] HotelPhotoForCreationDto hotelPhoto)
    {
        var createdHotelPhoto = await _service.HotelPhotoService.CreateHotelPhotoAsync(hotelId, hotelPhoto);
        return CreatedAtRoute("GetHotelPhotoForHotel", new { hotelId, id = createdHotelPhoto.Id }, createdHotelPhoto);
    }

    /// <summary>
    /// Creates a hotel photo collection
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="hotelPhotoCollection"></param>
    /// <returns>A newly created hotel photo collection</returns>
    /// <remarks>
    /// You can find a href to the newly created hotel photo collection in the Location header. <br />
    /// If ids parameter is null, or collection count mismatch comparing to ids, Bad Request will be returned in response. <br />
    /// If the hotel with hotelId does not exist, the response code will be 404. <br />
    /// </remarks>
    /// <response code="200">Returns the newly created list of items</response>
    /// <response code="400">If the collection or ids are null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("collection")]
    [ProducesResponseType(typeof(IEnumerable<HotelPhotoDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> CreateHotelPhotoCollection(Guid hotelId,
        [FromBody] IEnumerable<HotelPhotoForCreationDto> hotelPhotoCollection)
    {
        var (hotelPhotos, ids) = await _service.HotelPhotoService.CreateHotelPhotoCollectionAsync
            (hotelId, hotelPhotoCollection);
        return CreatedAtRoute("HotelPhotoCollection", new { hotelId, ids }, hotelPhotos);
    }

    /// <summary>
    /// Updates a hotel photo
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <param name="hotelPhoto"></param>
    /// <returns>Updated hotel photo</returns>
    /// <remarks>
    /// If the hotel with hotelId or hotel photo with id does not exist, the response code will be 404. <br />
    /// <i>You need to have an Admin or HotelOwner role to perform this action.</i>
    /// </remarks>
    /// <response code="200">Returns the updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="404">If the item does not exist</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(HotelPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> UpdateHotelPhoto(Guid hotelId, Guid id, [FromBody] HotelPhotoForUpdateDto hotelPhoto)
    {
        var updatedHotelPhoto = await _service.HotelPhotoService.UpdateHotelPhotoAsync(hotelId, id, hotelPhoto);
        return Ok(updatedHotelPhoto);
    }

    /// <summary>
    /// Partially updates a hotel photo
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated hotel photo</returns>
    /// <remarks>
    /// Sample request:
    /// 
    ///     [
    ///         {
    ///             "op": "add",
    ///             "path": "/path",
    ///             "value": "../../../Content/Images/Hotels/new-hotel-photo.jpeg"
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
    [ProducesResponseType(typeof(HotelPhotoDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    public async Task<IActionResult> PartiallyUpdateHotelPhoto(Guid hotelId, Guid id,
        [FromBody] JsonPatchDocument<HotelPhotoForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelPhotoToPatch, hotelPhotoEntity) = await _service.HotelPhotoService.GetHotelPhotoForPatchAsync(hotelId, id);
        patchDoc.ApplyTo(hotelPhotoToPatch);

        TryValidateModel(hotelPhotoToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedHotelPhoto = await _service.HotelPhotoService.SaveChangesForPatchAsync(hotelPhotoToPatch, hotelPhotoEntity);
        return Ok(updatedHotelPhoto);
    }

    /// <summary>
    /// Deletes a hotel photo
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <remarks>
    /// </remarks>
    /// <response code="204">Returns No content</response>
    /// <response code="404">If the item does not exist</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    public async Task<IActionResult> DeleteHotelPhoto(Guid hotelId, Guid id)
    {
        await _service.HotelPhotoService.DeleteHotelPhotoAsync(hotelId, id);
        return NoContent();
    }

    /// <summary>
    /// Shows available request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [HttpOptions]
    [ProducesResponseType(204)]
    public IActionResult GetHotelPhotosOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}