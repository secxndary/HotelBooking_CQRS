namespace Entities.Exceptions.BadRequest.Filtering;

public class MaxStarsRangeBadRequestException : BadRequestException
{
    public MaxStarsRangeBadRequestException()
        : base("Maximun amount of Stars can't be less than the minimum amount.")
    { }
}
