namespace Entities.Exceptions.BadRequest.Authentication;

public class RefreshTokenBadRequest : BadRequestException
{
    public RefreshTokenBadRequest()
        : base("Invalid client request. The TokenDto has invalid values.")
    { }
}