namespace Payment.Share.DataTransferObjects.Integrations.Stripe;

public class StripePaymentIntentResult
{
    public string PaymentIntentId { get; set; }
    public string ClientSecret { get; set; }
}