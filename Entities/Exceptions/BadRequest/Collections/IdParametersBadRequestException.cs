namespace Entities.Exceptions.BadRequest.Collections;

public class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException()
        : base("Parameter ids is null")
    { }
}