using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    Task<PagedList<Feedback>> GetFeedbacksForHotelAsync(Guid hotelId, FeedbackParameters feedbackParameters, bool trackChanges);
    Task<PagedList<Feedback>> GetFeedbacksForRoomAsync(Guid roomId, FeedbackParameters feedbackParameters, bool trackChanges);
    Task<PagedList<Feedback>> GetFeedbacksForReservationAsync(Guid reservationId, FeedbackParameters feedbackParameters, bool trackChanges);
    Task<Feedback?> GetFeedbackAsync(Guid id, bool trackChanges);
    void CreateFeedback(Feedback feedback);
    void DeleteFeedback(Feedback feedback);
}