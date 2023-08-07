using System.ComponentModel.DataAnnotations;
namespace Entities.Models.UserModels;

public class Hotel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(3000, ErrorMessage = "Maximum length for the Description is 3000 characters.")]
    public string? Description { get; set; }

    [Range(1, 5, ErrorMessage = "The stars should be in the range between 1 and 5.")]
    [Required(ErrorMessage = "Stars is a required field.")]
    public int Stars { get; set; }

    public ICollection<Room>? Rooms { get; set; }
    public ICollection<HotelPhoto>? HotelPhotos { get; set; }
}
