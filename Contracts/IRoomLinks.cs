using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.OutputDtos;
namespace Contracts;

public interface IRoomLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<RoomDto> roomsDto, string fields, Guid hotelId, HttpContext httpContext);
}