namespace Payment.Share.DataTransferObjects.Service.Commands;

public class CreatePaymentCommand
{
    public string ReferenceId { get; set; } = default!;


    public long Amount { get; set; }

    public string Currency { get; set; } = default!;
}