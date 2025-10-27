using Application.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Feature.Customer.Queries
{
    public record GetListCustomerQuery : IRequest<List<CustomerDTO>>;

    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, List<CustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDTO>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetListCustomer(cancellationToken);
            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                BirthDay = c.BirthDay,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address
            }).ToList();
        }
    }
}
