using MediatR;
namespace Application.Notifications;

public sealed record HotelDeletedNotification(Guid Id, bool TrackChanges)
    : INotification;