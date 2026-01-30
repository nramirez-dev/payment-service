using Payment.Share.DataTransferObjects.Service.Commands;

namespace Payment.Abstractions.UseCases;

public interface IUpdatePaymentStatusHandler
{
    Task HandleAsync(
        UpdatePaymentStatusCommand command,
        CancellationToken cancellationToken = default);
}