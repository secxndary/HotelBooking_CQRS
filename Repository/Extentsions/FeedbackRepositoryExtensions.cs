using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class FeedbackRepositoryExtensions
{
    public static IQueryable<Feedback> Search(this IQueryable<Feedback> feedbacks, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return feedbacks;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var feedbacksWithSearchTermInTextPositive = feedbacks
            .Where(f => f.TextPositive!.ToLower().Contains(lowerCaseTerm));

        var feedbacksWithSearchTermInTextNegative = feedbacks
            .Where(f => 
                !f.TextPositive!.ToLower().Contains(lowerCaseTerm) &&
                f.TextNegative!.ToLower().Contains(lowerCaseTerm));

        var result = feedbacksWithSearchTermInTextPositive
            .Union(feedbacksWithSearchTermInTextNegative);

        return result;
    }

    public static IQueryable<Feedback> Sort(this IQueryable<Feedback> feedbacks, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return feedbacks;

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Feedback>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return feedbacks;

        return feedbacks.OrderBy(orderQuery);
    }
}
