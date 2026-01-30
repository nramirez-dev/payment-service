namespace Payment.Share.DataTransferObjects.Api.Requests;

public class CreatePaymentRequest
{
    public string ReferenceId { get; set; } = default!;
    public long Amount { get; set; }
    public string Currency { get; set; } = default!;

}