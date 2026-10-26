using System.Data;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repository;
using Dapper;

namespace AirlineBookingSystem.Payments.Infrastructure.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbConnection _dbConnection;

    public PaymentRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task ProcessPaymentAsync(Payment payment)
    {
        const string sql = @"
        INSERT INTO Payments (Id, BookindId, Amount, PaymenDate)
        VALUES (@Id, @BookindId, @Amount, @PaymenDate);
        ";
        await _dbConnection.ExecuteAsync(sql, payment);
    }

    public async Task RefundPaymentAsync(Guid id)
    {
        const string sql = "DELETE FROM Payments WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}