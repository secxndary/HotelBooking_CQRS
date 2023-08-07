namespace Shared.DataTransferObjects.OutputDtos;

public record HotelPhotoDto
{
    public Guid Id { get; init; }
    public string? Path { get; init; }
}