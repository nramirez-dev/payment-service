using Payment.Model.Enums;

namespace Payment.Share.DataTransferObjects.Service.Results;

public class CreatePaymentResult
{
    public Guid PaymentId { get; init; }


    public string StripePaymentIntentId { get; init; } = default!;

    public string ClientSecret { get; init; } = default!;

    public PaymentStatus Status { get; init; }
}