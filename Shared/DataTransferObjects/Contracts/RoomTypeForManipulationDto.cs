using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record RoomTypeForManipulationDto
{
    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(300, ErrorMessage = "Maximum length for the Description is 300 characters.")]
    public string? Description { get; init; }
}