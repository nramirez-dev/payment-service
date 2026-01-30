using Payment.Model.Enums;

namespace Payment.Share.DataTransferObjects.Api.Responses;

public class CreatePaymentResponse
{
    public Guid PaymentId { get; set; }
    public string ClientSecret { get; set; } = default!;
    public PaymentStatus Status { get; set; }
}