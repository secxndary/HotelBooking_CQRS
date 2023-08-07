using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models.UserModels;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.UserServicesImpl;

public sealed class FeedbackService : IFeedbackService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public FeedbackService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForHotelAsync
        (Guid hotelId, FeedbackParameters feedbackParameters)
    {
        await CheckIfHotelExists(hotelId);

        var feedbacksWithMetaData = await _repository.Feedback.GetFeedbacksForHotelAsync(hotelId, feedbackParameters, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacksWithMetaData);
        
        return (feedbacks: feedbacksDto, metaData: feedbacksWithMetaData.MetaData);
    }

    public async Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForRoomAsync
        (Guid roomId, FeedbackParameters feedbackParameters)
    {
        await CheckIfRoomExists(roomId);

        var feedbacksWithMetaData = await _repository.Feedback.GetFeedbacksForRoomAsync(roomId, feedbackParameters, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacksWithMetaData);
       
        return (feedbacks: feedbacksDto, metaData: feedbacksWithMetaData.MetaData);
    }

    public async Task<(IEnumerable<FeedbackDto> feedbacks, MetaData metaData)> GetFeedbacksForReservationAsync
        (Guid reservationId, FeedbackParameters feedbackParameters)
    {
        await CheckIfReservationExists(reservationId);

        var feedbacksWithMetaData = await _repository.Feedback.GetFeedbacksForReservationAsync(reservationId, feedbackParameters, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacksWithMetaData);

        return (feedbacks: feedbacksDto, metaData: feedbacksWithMetaData.MetaData);
    }

    public async Task<FeedbackDto> GetFeedbackAsync(Guid id)
    {
        var feedback = await GetFeedbackAndCheckIfItExists(id, trackChanges: false);
        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public async Task<FeedbackDto> CreateFeedbackAsync(FeedbackForCreationDto feedback)
    {
        var feedbackEntity = _mapper.Map<Feedback>(feedback);
        _repository.Feedback.CreateFeedback(feedbackEntity);
        await _repository.SaveAsync();

        var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
        return feedbackToReturn;
    }

    public async Task<FeedbackDto> UpdateFeedbackAsync(Guid id, FeedbackForUpdateDto feedbackForUpdate)
    {
        await CheckIfReservationExists(feedbackForUpdate.ReservationId);

        var feedbackEntity = await GetFeedbackAndCheckIfItExists(id, trackChanges: true);
        _mapper.Map(feedbackForUpdate, feedbackEntity);
        await _repository.SaveAsync();

        var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
        return feedbackToReturn;
    }

    public async Task<(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)> GetFeedbackForPatchAsync(Guid id)
    {
        var feedbackEntity = await GetFeedbackAndCheckIfItExists(id, trackChanges: true);
        var feedbackToPatch = _mapper.Map<FeedbackForUpdateDto>(feedbackEntity);
        return (feedbackToPatch, feedbackEntity);
    }

    public async Task<FeedbackDto> SaveChangesForPatchAsync(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)
    {
        await CheckIfReservationExists(feedbackToPatch.ReservationId);

        _mapper.Map(feedbackToPatch, feedbackEntity);
        await _repository.SaveAsync();

        var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
        return feedbackToReturn;
    }

    public async Task DeleteFeedbackAsync(Guid id)
    {
        var feedback = await GetFeedbackAndCheckIfItExists(id, trackChanges: false);
        _repository.Feedback.DeleteFeedback(feedback);
        await _repository.SaveAsync();
    }


    private async Task CheckIfHotelExists(Guid hotelId)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
    }

    private async Task CheckIfRoomExists(Guid roomId)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);
    }

    private async Task CheckIfReservationExists(Guid reservationId)
    {
        var reservation = await _repository.Reservation.GetReservationAsync(reservationId, trackChanges: false);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);
    }

    private async Task<Feedback> GetFeedbackAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var feedback = await _repository.Feedback.GetFeedbackAsync(id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);
        return feedback;
    }
}