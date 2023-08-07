namespace Shared.DataTransferObjects.OutputDtos;

public record FeedbackDto
{
    public Guid Id { get; init; }
    public string? TextPositive { get; init; }
    public string? TextNegative { get; init; }
    public Guid ReservationId { get; init; }
}