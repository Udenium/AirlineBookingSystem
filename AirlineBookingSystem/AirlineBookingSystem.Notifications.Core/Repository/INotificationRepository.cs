using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Core.Repository;

public interface INotificationRepository
{
    Task LogNotificationAsync(Notification notification);
}