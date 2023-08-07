namespace Entities.Exceptions.BadRequest.Collections;

public class RoomPhotoCollectionBadRequest : BadRequestException
{
    public RoomPhotoCollectionBadRequest()
        : base("Room photo collection sent from a client is null.")
    { }
}