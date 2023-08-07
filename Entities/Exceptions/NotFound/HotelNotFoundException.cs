namespace Entities.Exceptions.NotFound;

public class HotelNotFoundException : NotFoundException
{
    public HotelNotFoundException(Guid hotelId)
        : base($"Hotel with id: {hotelId} doesn't exist in the database.")
    { }
}
