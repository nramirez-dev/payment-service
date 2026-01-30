
using Payment.Model.Enums;

namespace Payment.Model;

public class Payment
{
    public Guid Id { get; private set; }


    public string ReferenceId { get; private set; }


    public long Amount { get; private set; }
    public string Currency { get; private set; }

    public PaymentStatus Status { get; private set; }

    // Stripe
    public string StripePaymentIntentId { get; private set; }
    public string StripeClientSecret { get; private set; }


    public int RetryCount { get; private set; }


    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Payment()
    {
    }

    public Payment(
        string referenceId,
        long amount,
        string currency,
        string stripePaymentIntentId,
        string stripeClientSecret)
    {
        Id = Guid.NewGuid();
        ReferenceId = referenceId;
        Amount = amount;
        Currency = currency;

        StripePaymentIntentId = stripePaymentIntentId;
        StripeClientSecret = stripeClientSecret;

        Status = PaymentStatus.Pending;
        RetryCount = 0;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkProcessing()
    {
        Status = PaymentStatus.Processing;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkSucceeded()
    {
        Status = PaymentStatus.Succeeded;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkFailed()
    {
        Status = PaymentStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void IncrementRetry()
    {
        RetryCount++;
        UpdatedAt = DateTime.UtcNow;
    }
}