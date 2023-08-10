using Application.Notifications;
using Contracts;
using MediatR;
namespace Application.Handlers;

public sealed class EmailHandler : INotificationHandler<HotelDeletedNotification>
{
    private readonly ILoggerManager _logger;
    public EmailHandler(ILoggerManager logger) => _logger = logger;


    public async Task Handle(HotelDeletedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogWarn($"Delete action for hotel with id: {notification.Id} has occured.");
        await Task.CompletedTask;
    }
}
