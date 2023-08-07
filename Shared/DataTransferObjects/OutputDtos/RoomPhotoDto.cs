namespace Shared.DataTransferObjects.OutputDtos;

public record RoomPhotoDto
{
    public Guid Id { get; init; }
    public string? Path { get; init; }
}