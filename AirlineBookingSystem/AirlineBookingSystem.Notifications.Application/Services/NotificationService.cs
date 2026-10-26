using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService : INotificationService
{
    public async Task SentNotificationAsync(Notification notification)
    {
        //Simulate sending a notification (email or sms)
        Console.WriteLine($"Notification sent to {notification.Recipient} : {notification.Message}");
    }
}