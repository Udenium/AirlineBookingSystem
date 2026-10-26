using System.Data;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repository;
using Dapper;

namespace AirlineBookingSystem.Bookings.Infrastructure.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly IDbConnection _dbConnection;
    
    public BookingRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<Booking> GetBookingByIdAsync(Guid id)
    {
        const string sql = "select * from Bookings where Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Booking>(sql, new { Id = id });
    }

    public async Task AddBookingAsync(Booking booking)
    {
        const string sql = @"
        INSERT INTO Bookings(Id, FlightId, PassengerName, SeatNumber, BookingDate)
        VALUES(@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";

        await _dbConnection.ExecuteAsync(sql, booking);
    }
}