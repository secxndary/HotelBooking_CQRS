using Shared.DataTransferObjects.Contracts;
namespace Shared.DataTransferObjects.InputDtos;

public record HotelForCreationDto : HotelForManipulationDto
{
    public IEnumerable<RoomForCreationDto>? Rooms { get; init; }
}