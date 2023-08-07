using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record RoomPhotoForManipulationDto
{
    [Required(ErrorMessage = "Path is a required field.")]
    public string? Path { get; init; }
}