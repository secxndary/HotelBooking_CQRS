using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class RoomPhoto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Path is a required field.")]
    public string? Path { get; set; }

    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }
}
