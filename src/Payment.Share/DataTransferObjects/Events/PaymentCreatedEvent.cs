namespace Payment.Share.DataTransferObjects.Events;

public class PaymentCreatedEvent
{
    public Guid PaymentId { get; init; }


    public string ReferenceId { get; init; } = default!;


    public long Amount { get; init; }


    public string Currency { get; init; } = default!;

    public DateTime CreatedAt { get; init; }
}