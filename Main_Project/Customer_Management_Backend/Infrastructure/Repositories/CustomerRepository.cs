using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerdbContext _context;

    public CustomerRepository(CustomerdbContext context)
    {
        _context = context;
    }

    // nhớ cái references !!!!
    public async Task<List<Customer>> GetListCustomer(CancellationToken cancellationToken = default)
    {
        return await _context.Customers.ToListAsync(cancellationToken);
    }

    public async Task<Customer> addAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return customer;
    }

    public async Task<Customer> updateAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return customer;
    }

    public async Task<bool> deleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}