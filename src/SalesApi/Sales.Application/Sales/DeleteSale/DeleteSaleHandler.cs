using FluentValidation;
using MediatR;
using Sales.Domain.Events;
using Sales.Domain.Repositories;

namespace Sales.Application.Sales.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleEventHandler _saleEventHandler;


    public DeleteSaleHandler(
        ISaleRepository saleRepository, ISaleEventHandler saleEventHandler)
    {
        _saleRepository = saleRepository;
        _saleEventHandler = saleEventHandler;
    }

    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);Temporario
        var success = await _saleRepository.CancelledAsync(request.Id, cancellationToken);
       
        // queue
        await _saleEventHandler.PublishSaleCancelledEvent(request.Id, DateTime.UtcNow, Domain.Enums.StatusSale.Cancelled, cancellationToken);
        
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}
