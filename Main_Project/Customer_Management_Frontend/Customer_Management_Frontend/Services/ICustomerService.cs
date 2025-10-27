using Customer_Management_Frontend.Models;

namespace Customer_Management_Frontend.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel> CreateCustomerAsync(CreateCustomerViewModel customer);
        Task<CustomerViewModel> UpdateCustomerAsync(int id, CustomerViewModel customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}