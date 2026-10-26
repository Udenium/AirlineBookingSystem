using AirlineBookingSystem.Notifications.Application.Commands;
using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MediatR;

namespace AirlineBookingSystem.Notifications.Application.Handlers;

public class SentNotificationHandler : IRequestHandler<SentNotificationCommand>
{
    private readonly INotificationService _notificationService;

    public SentNotificationHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public async Task Handle(SentNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type
        };
        
        await _notificationService.SentNotificationAsync(notification);
    }
}