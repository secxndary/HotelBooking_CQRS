using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record FeedbackForManipulationDto
{
    [Required(ErrorMessage = "TextPositive is a required field.")]
    [MaxLength(5000, ErrorMessage = "Maximum length for the TextPositive is 5000 characters.")]
    public string? TextPositive { get; init; }

    [Required(ErrorMessage = "TextNegative is a required field.")]
    [MaxLength(5000, ErrorMessage = "Maximum length for the TextNegative is 5000 characters.")]
    public string? TextNegative { get; init; }

    [Required(ErrorMessage = "ReservationId is a required field.")]
    public Guid ReservationId { get; init; }
}