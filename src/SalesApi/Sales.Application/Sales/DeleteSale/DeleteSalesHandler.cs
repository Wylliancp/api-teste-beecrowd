using FluentValidation;
using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Sales.DeleteSale;

public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, DeleteSalesResponse>
{
    private readonly ISaleRepository _saleRepository;

    public DeleteSalesHandler(
        ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<DeleteSalesResponse> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);Temporario
        var success = await _saleRepository.CancelledAsync(request.Id, cancellationToken);
        
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return new DeleteSalesResponse { Success = true };
    }
}
