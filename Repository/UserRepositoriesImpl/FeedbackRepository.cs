using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Feedback>> GetFeedbacksForHotelAsync(Guid hotelId, FeedbackParameters feedbackParameters, bool trackChanges)
    {
        var feedbacks = await FindByCondition(f => f.Reservation!.Room!.HotelId.Equals(hotelId), trackChanges)
            .Search(feedbackParameters.SearchTerm)
            .Sort(feedbackParameters.OrderBy)
            .ToListAsync();

        return PagedList<Feedback>.ToPagedList(feedbacks, feedbackParameters.PageNumber, feedbackParameters.PageSize);
    }

    public async Task<PagedList<Feedback>> GetFeedbacksForRoomAsync(Guid roomId, FeedbackParameters feedbackParameters, bool trackChanges)
    {
        var feedbacks = await FindByCondition(f => f.Reservation!.RoomId.Equals(roomId), trackChanges)
            .Search(feedbackParameters.SearchTerm)
            .Sort(feedbackParameters.OrderBy)
            .ToListAsync();

        return PagedList<Feedback>.ToPagedList(feedbacks, feedbackParameters.PageNumber, feedbackParameters.PageSize);
    }

    public async Task<PagedList<Feedback>> GetFeedbacksForReservationAsync(Guid reservationId, FeedbackParameters feedbackParameters, bool trackChanges)
    {
        var feedbacks = await FindByCondition(f => f.ReservationId.Equals(reservationId), trackChanges)
            .Search(feedbackParameters.SearchTerm)
            .Sort(feedbackParameters.OrderBy)
            .ToListAsync();

        return PagedList<Feedback>.ToPagedList(feedbacks, feedbackParameters.PageNumber, feedbackParameters.PageSize);
    }

    public async Task<Feedback?> GetFeedbackAsync(Guid id, bool trackChanges) =>
        await FindByCondition(f => f.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateFeedback(Feedback feedback) =>
        Create(feedback);

    public void DeleteFeedback(Feedback feedback) =>
        Delete(feedback);
}