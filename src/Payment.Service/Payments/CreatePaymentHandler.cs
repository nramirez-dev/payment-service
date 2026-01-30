using FluentValidation;
using Payment.Abstractions;
using Payment.Abstractions.Messaging;
using Payment.Abstractions.UseCases;
using Payment.Model;
using Payment.Share.DataTransferObjects.Events;
using Payment.Share.DataTransferObjects.Service.Commands;
using Payment.Share.DataTransferObjects.Service.Results;


public class CreatePaymentHandler : ICreatePaymentHandler
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IStripePaymentService _stripePaymentService;
    private readonly IEventPublisher _eventPublisher;
    private readonly IValidator<CreatePaymentCommand> _validator;

    public CreatePaymentHandler(
        IPaymentRepository paymentRepository,
        IStripePaymentService stripePaymentService,
        IEventPublisher eventPublisher,
        IValidator<CreatePaymentCommand> validator)
    {
        _paymentRepository = paymentRepository;
        _stripePaymentService = stripePaymentService;
        _eventPublisher = eventPublisher;
        _validator = validator;
    }

    public async Task<CreatePaymentResult> HandleAsync(
        CreatePaymentCommand command,
        CancellationToken cancellationToken = default)
    {
        await _validator.ValidateAndThrowAsync(command, cancellationToken);


        var stripeResult = await _stripePaymentService.CreatePaymentIntentAsync(
            command.Amount,
            command.Currency,
            command.ReferenceId,
            cancellationToken);


        var payment = new Payment.Model.Payment(
            command.ReferenceId,
            command.Amount,
            command.Currency,
            stripeResult.PaymentIntentId,
            stripeResult.ClientSecret);


        await _paymentRepository.AddAsync(payment, cancellationToken);


        await _eventPublisher.PublishAsync(
            new PaymentCreatedEvent
            {
                PaymentId = payment.Id,
                ReferenceId = payment.ReferenceId,
                Amount = payment.Amount,
                Currency = payment.Currency,
                CreatedAt = DateTime.UtcNow
            },
            cancellationToken);


        return new CreatePaymentResult
        {
            PaymentId = payment.Id,
            StripePaymentIntentId = stripeResult.PaymentIntentId,
            ClientSecret = stripeResult.ClientSecret,
            Status = payment.Status
        };
    }
}