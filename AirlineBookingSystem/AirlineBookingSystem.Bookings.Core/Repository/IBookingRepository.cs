using AirlineBookingSystem.Bookings.Core.Entities;

namespace AirlineBookingSystem.Bookings.Core.Repository;

public interface IBookingRepository
{
    Task<Booking> GetBookingByIdAsync(Guid id);
    Task AddBookingAsync(Booking booking);
}