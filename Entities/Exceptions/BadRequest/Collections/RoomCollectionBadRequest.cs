namespace Entities.Exceptions.BadRequest.Collections;

public class RoomCollectionBadRequest : BadRequestException
{
    public RoomCollectionBadRequest()
        : base("Room collection sent from a client is null.")
    { }
}