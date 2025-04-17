using AutoMapper;
using FluentValidation;
using MediatR;
using Sales.Application.Products.CreateProduct;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;

namespace Sales.Application.Sales.CreateSale;

public class CreateSalesHandler : IRequestHandler<CreateSalesCommand, CreateSalesResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }
    public async Task<CreateSalesResult> Handle(CreateSalesCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Sale>(command);

        var createdUser = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSalesResult>(createdUser);
        return result;
    }
}
