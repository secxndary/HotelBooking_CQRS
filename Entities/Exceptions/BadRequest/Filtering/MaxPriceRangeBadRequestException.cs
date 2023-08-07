namespace Entities.Exceptions.BadRequest.Filtering;

public class MaxPriceRangeBadRequestException : BadRequestException
{
    public MaxPriceRangeBadRequestException()
        : base("Maximun Price can't be less than the minimum Price.")
    { }
}
