namespace Entities.Exceptions.BadRequest.Collections;

public class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException()
        : base("Collection count mismatch comparing to ids.")
    { }
}