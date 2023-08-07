namespace Shared.DataTransferObjects.OutputDtos;

public record ReservationDto
{
    public Guid Id { get; init; }
    public DateTime DateEntry { get; init; }
    public DateTime DateExit { get; init; }
    public string? UserId { get; init; }
}