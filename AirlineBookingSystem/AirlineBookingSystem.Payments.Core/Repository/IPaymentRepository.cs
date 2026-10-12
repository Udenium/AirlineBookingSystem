using AirlineBookingSystem.Payments.Core.Entities;

namespace AirlineBookingSystem.Payments.Core.Repository;

public interface IPaymentRepository
{
    Task ProcessPaymentAsync(Payment payment);
    Task RefundPaymentAsync(Guid id);
}