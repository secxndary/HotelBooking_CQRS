namespace Shared.DataTransferObjects.UpdateDtos;

public record FeedbackForUpdateDto
(
    string TextPositive,
    string TextNegative,
    Guid ReservationId
);