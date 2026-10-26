using System.Data;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repository;
using Dapper;

namespace AirlineBookingSystem.Flights.Infrastructure.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly IDbConnection _dbConnection;

    public FlightRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public Task<IEnumerable<Flight>> GetAllFlightsAsync()
    {
        const string sql = "select * from Flights";
        return _dbConnection.QueryAsync<Flight>(sql);
    }

    public async Task AddFlightAsync(Flight flight)
    {
        const string sql = @"
        INSERT INTO Flights(Id, FlightNumber, Origin, Destination, DepartureTime, ArrivalTime)
        VALUES (@Id, @FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)
        ";
        
        await _dbConnection.ExecuteAsync(sql, flight);
    }

    public Task DeleteFlightAsync(Guid id)
    {
        const string sql = "DELETE FROM Flights WHERE Id = @Id";
        
        return _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}