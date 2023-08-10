using Application.Notifications;
using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using MediatR;
namespace Application.Handlers;

public class DeleteHotelHandler : INotificationHandler<HotelDeletedNotification>
{
    private readonly IRepositoryManager _repository;

    public DeleteHotelHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }


    public async Task Handle(HotelDeletedNotification notification, CancellationToken cancellationToken)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(notification.Id, notification.TrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(notification.Id);

        _repository.Hotel.DeleteHotel(hotel);
        await _repository.SaveAsync();
    }
}