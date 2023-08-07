namespace Shared.DataTransferObjects.OutputDtos;

public record HotelDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int Stars { get; init; }
}