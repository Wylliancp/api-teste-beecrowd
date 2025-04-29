using AutoMapper;
using FluentValidation;
using MediatR;
using Sales.Application.Products.CreateProduct;
using Sales.Domain.Entities;
using Sales.Domain.Events;
using Sales.Domain.Repositories;

namespace Sales.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleEventHandler _saleEventHandler;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, ISaleEventHandler saleEventHandler, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _saleEventHandler = saleEventHandler;
        _mapper = mapper;
    }
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Sale>(command);
        
        if(sale.ItNotPossibleToSellAbove20IdenticalItems())
            throw new ValidationException("It is not possible to sell more than 20 identical items.");
        
        var createdUser = await _saleRepository.CreateAsync(sale, cancellationToken);
        //queue
        await _saleEventHandler.PublishSaleCreatedEvent(createdUser.Id, createdUser.CustomerId, createdUser.SaleDate, cancellationToken);
        
        var result = _mapper.Map<CreateSaleResult>(createdUser);
        return result;
    }
}
