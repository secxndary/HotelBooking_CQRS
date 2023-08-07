namespace Entities.Exceptions.NotFound;

public class RoomNotFoundException : NotFoundException
{
    public RoomNotFoundException(Guid roomId)
        : base($"Room with id: {roomId} doesn't exist in the database.")
    { }
}
