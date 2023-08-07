using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record ReservationForManipulationDto
{
    [Required(ErrorMessage = "DateEntry is a required field.")]
    public DateTime DateEntry { get; init; }

    [Required(ErrorMessage = "DateExit is a required field.")]
    public DateTime DateExit { get; init; }

    [Required(ErrorMessage = "UserId is a required field.")]
    public string? UserId { get; init; }
}