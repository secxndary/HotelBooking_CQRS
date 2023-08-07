using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects.OutputDtos;
namespace HotelBooking.Utility;

public class RoomLinks : IRoomLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<RoomDto> _dataShaper;

    public RoomLinks(LinkGenerator linkGenerator, IDataShaper<RoomDto> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }


    public LinkResponse TryGenerateLinks(IEnumerable<RoomDto> roomsDto, string fields, Guid hotelId, HttpContext httpContext)
    {
        var shapedRooms = ShapeData(roomsDto, fields);

        if (ShouldGenerateLinks(httpContext))
            return ReturnLinkedRooms(roomsDto, fields, hotelId, httpContext, shapedRooms);

        return ReturnShapedRooms(shapedRooms);
    }

    private List<Entity> ShapeData(IEnumerable<RoomDto> roomsDto, string fields) =>
        _dataShaper.ShapeData(roomsDto, fields)
            .Select(e => e.Entity)
            .ToList();

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        var mediaType = httpContext.Items["AcceptHeaderMediaType"] as MediaTypeHeaderValue;
        return mediaType!.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedRooms(List<Entity> shapedRooms) =>
        new LinkResponse { ShapedEntities = shapedRooms };

    private LinkResponse ReturnLinkedRooms(IEnumerable<RoomDto> roomsDto, string fields, Guid hotelId, HttpContext httpContext, List<Entity> shapedRooms)
    {
        var roomDtoList = roomsDto.ToList();

        for (var index = 0; index < roomDtoList.Count; index++) 
        {
            var roomLinks = CreateLinksForRoom(httpContext, hotelId, roomDtoList[index].Id, fields);
            shapedRooms[index].Add("Links", roomLinks);
        }

        var roomCollection = new LinkCollectionWrapper<Entity>(shapedRooms);
        var linkedRooms = CreateLinksForRooms(httpContext, roomCollection);

        return new LinkResponse { HasLinks = true, LinkedEntities = linkedRooms };
    }

    private List<Link> CreateLinksForRoom(HttpContext httpContext, Guid hotelId, Guid id, string fields = "")
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetRoomForHotel", values: new { hotelId, id, fields })!,
                "self",
                "GET"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteRoomForHotel", values: new { hotelId, id })!,
                "delete_room",
                "DELETE"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateRoomForHotel", values: new { hotelId, id })!,
                "update_room",
                "PUT"),
            new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateRoomForHotel", values: new { hotelId, id })!,
                "partially_update_room",
                "PATCH")
        };

        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForRooms(HttpContext httpContext, LinkCollectionWrapper<Entity> roomsWrapper)
    {
        roomsWrapper.Links.Add(
            new Link(_linkGenerator.GetUriByAction(httpContext, "GetRoomsForHotel", values: new { })!,
                "self",
                "GET"));

        return roomsWrapper;
    }
}