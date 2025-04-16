using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;

namespace Sales.Application.Customers.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.ToString());

        var user = _mapper.Map<Customer>(command);

        var createdUser = await _customerRepository.CreateAsync(user, cancellationToken);
        var result = _mapper.Map<CreateCustomerResult>(createdUser);
        return result;
    }
}
