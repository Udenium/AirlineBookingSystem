using AirlineBookingSystem.Flights.Core.Entities;

namespace AirlineBookingSystem.Flights.Core.Repository;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
    Task DeleteFlightAsync(Guid id);
}