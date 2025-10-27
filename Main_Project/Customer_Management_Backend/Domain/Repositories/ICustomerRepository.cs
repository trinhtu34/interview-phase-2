using Domain.Entities;

namespace Domain.Repositories;
public interface ICustomerRepository
{
    Task<List<Customer>> GetListCustomer(CancellationToken cancellationToken = default);
    //Task<Customer?> GetCustomerById(int id, CancellationToken cancellationToken = default);
    Task<Customer> addAsync(Customer customer, CancellationToken cancellationToken = default);
    Task<Customer> updateAsync(Customer customer, CancellationToken cancellationToken = default);
    Task<bool> deleteAsync(int id, CancellationToken cancellationToken = default);
}