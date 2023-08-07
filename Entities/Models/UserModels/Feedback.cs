using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class Feedback
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "TextPositive is a required field.")]
    [MaxLength(5000, ErrorMessage = "Maximum length for the TextPositive is 5000 characters.")]
    public string? TextPositive { get; set; }

    [Required(ErrorMessage = "TextNegative is a required field.")]
    [MaxLength(5000, ErrorMessage = "Maximum length for the TextNegative is 5000 characters.")]
    public string? TextNegative { get; set; }

    [ForeignKey(nameof(Reservation))]
    public Guid ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}
