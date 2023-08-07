using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class HotelPhoto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Path is a required field.")]
    public string? Path { get; set; }

    [ForeignKey(nameof(Hotel))]
    public Guid HotelId { get; set; }
    public Hotel? Hotel { get; set; }
}
