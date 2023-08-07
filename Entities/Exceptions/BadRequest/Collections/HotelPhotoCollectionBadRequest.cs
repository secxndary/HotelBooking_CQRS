namespace Entities.Exceptions.BadRequest.Collections;

public class HotelPhotoCollectionBadRequest : BadRequestException
{
    public HotelPhotoCollectionBadRequest()
        : base("Hotel photo collection sent from a client is null.")
    { }
}