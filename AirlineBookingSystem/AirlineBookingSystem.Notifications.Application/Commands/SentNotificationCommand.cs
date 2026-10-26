using MediatR;

namespace AirlineBookingSystem.Notifications.Application.Commands;

public record SentNotificationCommand(string Recipient, string Message, string Type) : IRequest;