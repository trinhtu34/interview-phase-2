using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Feature.Customer.Commands;

public record CreateCustomerCommand(string FullName, DateOnly? BirthDay, string Email, string PhoneNumber, string? Address) : IRequest<CustomerDTO>;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customer
        {
            FullName = request.FullName,
            BirthDay = request.BirthDay,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address
        };

        var createdCustomer = await _customerRepository.addAsync(customer, cancellationToken);
        
        return new CustomerDTO
        {
            Id = createdCustomer.Id,
            FullName = createdCustomer.FullName,
            BirthDay = createdCustomer.BirthDay,
            Email = createdCustomer.Email,
            PhoneNumber = createdCustomer.PhoneNumber,
            Address = createdCustomer.Address
        };
    }
}
