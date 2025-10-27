using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Feature.Customer.Commands
{
    public record UpdateCustomerCommand(int Id, string FullName, DateOnly? BirthDay, string Email, string PhoneNumber, string? Address) : IRequest<CustomerDTO>;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer
            {
                Id = request.Id,
                FullName = request.FullName,
                BirthDay = request.BirthDay,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            var updatedCustomer = await _customerRepository.updateAsync(customer, cancellationToken);
            
            return new CustomerDTO
            {
                Id = updatedCustomer.Id,
                FullName = updatedCustomer.FullName,
                BirthDay = updatedCustomer.BirthDay,
                Email = updatedCustomer.Email,
                PhoneNumber = updatedCustomer.PhoneNumber,
                Address = updatedCustomer.Address
            };
        }
    }
}
