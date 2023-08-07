namespace Entities.Exceptions.NotFound;

public class FeedbackNotFoundException : NotFoundException
{
    public FeedbackNotFoundException(Guid feedbackId)
        : base($"Feedback with id: {feedbackId} doesn't exist in the database.")
    { }
}