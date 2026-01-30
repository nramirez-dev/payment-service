namespace Payment.Model.Enums;

public enum PaymentFailureReason
{
    Unknown = 0,
    CardDeclined = 1,
    InsufficientFunds = 2,
    ExpiredCard = 3,
    ProcessingError = 4,
    FraudSuspected = 5
}