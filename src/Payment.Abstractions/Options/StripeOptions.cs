namespace Payment.Abstractions.Options;

public class StripeOptions
{
    public const string SectionName = "Stripe";


    public string SecretKey { get; set; } = default!;


    public bool TestMode { get; set; }
}