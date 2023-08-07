using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class Room
{
    public Guid Id { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "The Price should not be less than 0.")]
    [Required(ErrorMessage = "Price is a required field.")]
    public double Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "The Quantity should not be less than 0.")]
    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; set; }

    [Range(1, 16, ErrorMessage = "The SleepingPlaces should be in the range between 1 and 16.")]
    [Required(ErrorMessage = "SleepingPlaces is a required field.")]
    public int SleepingPlaces { get; set; }

    [ForeignKey(nameof(Hotel))]
    public Guid HotelId { get; set; }
    public Hotel? Hotel { get; set; }

    [ForeignKey(nameof(RoomType))]
    public Guid RoomTypeId { get; set; }
    public RoomType? RoomType { get; set; }

    public ICollection<RoomPhoto>? RoomPhotos { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
}