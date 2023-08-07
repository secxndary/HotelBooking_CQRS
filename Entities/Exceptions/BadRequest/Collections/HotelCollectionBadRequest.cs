namespace Entities.Exceptions.BadRequest.Collections;

public class HotelCollectionBadRequest : BadRequestException
{
    public HotelCollectionBadRequest()
        : base("Hotel collection sent from a client is null.")
    { }
}