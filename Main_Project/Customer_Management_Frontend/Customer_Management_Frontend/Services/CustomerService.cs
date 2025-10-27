using Customer_Management_Frontend.Models;
using System.Text;
using System.Text.Json;

namespace Customer_Management_Frontend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly ILogger<CustomerService> _logger;
        private readonly string? apiBaseUrl;

        public CustomerService(HttpClient httpClient, ILogger<CustomerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            
            apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                throw new InvalidOperationException("cannot load base api from .env");
            }
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<CustomerViewModel>> GetAllCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{apiBaseUrl}/Customer");
                response.EnsureSuccessStatusCode();
                
                var json = await response.Content.ReadAsStringAsync();
                var customers = JsonSerializer.Deserialize<List<CustomerViewModel>>(json, _jsonOptions);
                
                return customers ?? new List<CustomerViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting customers from API");
                return new List<CustomerViewModel>();
            }
        }

        public async Task<CustomerViewModel> CreateCustomerAsync(CreateCustomerViewModel customer)
        {
            try
            {
                var json = JsonSerializer.Serialize(customer, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync($"{apiBaseUrl}/Customer", content);
                response.EnsureSuccessStatusCode();
                
                var responseJson = await response.Content.ReadAsStringAsync();
                var createdCustomer = JsonSerializer.Deserialize<CustomerViewModel>(responseJson, _jsonOptions);
                
                return createdCustomer ?? new CustomerViewModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customer: {@Customer}", customer);
                throw;
            }
        }

        public async Task<CustomerViewModel> UpdateCustomerAsync(int id, CustomerViewModel customer)
        {
            try
            {
                var json = JsonSerializer.Serialize(customer, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PutAsync($"{apiBaseUrl}/Customer/{id}", content);
                response.EnsureSuccessStatusCode();
                
                var responseJson = await response.Content.ReadAsStringAsync();
                var updatedCustomer = JsonSerializer.Deserialize<CustomerViewModel>(responseJson, _jsonOptions);
                
                return updatedCustomer ?? new CustomerViewModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating customer with ID {CustomerId}: {@Customer}", id, customer);
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{apiBaseUrl}/Customer/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    _logger.LogWarning("Failed to delete customer with ID {CustomerId}. Status: {StatusCode}", id, response.StatusCode);
                }
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting customer with ID {CustomerId}", id);
                return false;
            }
        }
    }
}