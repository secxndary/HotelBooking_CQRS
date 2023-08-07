using System.ComponentModel.DataAnnotations;
namespace Entities.Models.UserModels;

public class RoomType
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(300, ErrorMessage = "Maximum length for the Description is 300 characters.")]
    public string? Description { get; set; }

    public ICollection<Room>? Rooms { get; set; }
}
