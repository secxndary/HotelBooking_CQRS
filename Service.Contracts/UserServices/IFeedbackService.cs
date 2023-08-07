using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IFeedbackService
{
    Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForHotelAsync
        (Guid hotelId, FeedbackParameters feedbackParameters);
    Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForRoomAsync
        (Guid roomId, FeedbackParameters feedbackParameters);
    Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForReservationAsync
        (Guid reservationId, FeedbackParameters feedbackParameters);
    Task<FeedbackDto> GetFeedbackAsync(Guid id);
    Task<FeedbackDto> CreateFeedbackAsync(FeedbackForCreationDto feedback);
    Task<FeedbackDto> UpdateFeedbackAsync(Guid id, FeedbackForUpdateDto feedbackForUpdate);
    Task<(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)> GetFeedbackForPatchAsync(Guid id);
    Task<FeedbackDto> SaveChangesForPatchAsync(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity);
    Task DeleteFeedbackAsync(Guid id);
}