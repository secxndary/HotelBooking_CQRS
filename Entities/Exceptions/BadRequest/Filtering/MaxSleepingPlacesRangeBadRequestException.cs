namespace Entities.Exceptions.BadRequest.Filtering;

public class MaxSleepingPlacesRangeBadRequestException : BadRequestException
{
    public MaxSleepingPlacesRangeBadRequestException()
        : base("Maximun amount of Sleeping places can't be less than the minimum amount.")
    { }
}
