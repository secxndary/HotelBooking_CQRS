namespace Entities.Exceptions.NotFound;

public class RoomPhotoNotFoundException : NotFoundException
{
    public RoomPhotoNotFoundException(Guid roomPhotoId)
        : base($"Room photo with id: {roomPhotoId} doesn't exist in the database.")
    { }
}