using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record HotelPhotoForManipulationDto
{
    [Required(ErrorMessage = "Path is a required field.")]
    public string? Path { get; init; }
}