namespace Entities.Exceptions.BadRequest.Filtering;

public class MaxDateEntryRangeBadRequestException : BadRequestException
{
    public MaxDateEntryRangeBadRequestException()
        : base("Maximun Entry date can't be less than the minimum Entry date.")
    { }
}
