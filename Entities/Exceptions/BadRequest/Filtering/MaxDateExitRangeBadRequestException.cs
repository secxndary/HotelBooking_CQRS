namespace Entities.Exceptions.BadRequest.Filtering;

public class MaxDateExitRangeBadRequestException : BadRequestException
{
    public MaxDateExitRangeBadRequestException()
        : base("Maximun Exit date can't be less than the minimum Exit date.")
    { }
}
