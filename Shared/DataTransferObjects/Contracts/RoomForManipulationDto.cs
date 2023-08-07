using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record RoomForManipulationDto
{
    [Range(0, 99999, ErrorMessage = "The Price should be in range between 0 and 99999.")]
    [Required(ErrorMessage = "Price is a required field.")]
    public int Price { get; init; }

    [Range(0, 999, ErrorMessage = "The Quantity should be in range between 0 and 999.")]
    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; init; }

    [Range(1, 16, ErrorMessage = "The SleepingPlaces should be in the range between 1 and 16.")]
    [Required(ErrorMessage = "SleepingPlaces is a required field.")]
    public int SleepingPlaces { get; init; }

    [Required(ErrorMessage = "RoomTypeId is a required field.")]
    public Guid RoomTypeId { get; init; }
}