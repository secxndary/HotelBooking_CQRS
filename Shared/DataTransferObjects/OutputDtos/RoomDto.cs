namespace Shared.DataTransferObjects.OutputDtos;

public record RoomDto
{
    public Guid Id { get; init; }
    public int Price { get; init; }
    public int Quantity { get; init; }
    public int SleepingPlaces { get; init; }
    public Guid RoomTypeId { get; init; }
}