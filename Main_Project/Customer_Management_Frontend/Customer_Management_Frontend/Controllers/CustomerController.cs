using Customer_Management_Frontend.Models;
using Customer_Management_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Management_Frontend.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.CreateCustomerAsync(customer);
                    TempData["SuccessMessage"] = "Khách hàng đã được tạo thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customers = await _customerService.GetAllCustomersAsync();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerViewModel customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateCustomerAsync(id, customer);
                    TempData["SuccessMessage"] = "Khách hàng đã được cập nhật thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customers = await _customerService.GetAllCustomersAsync();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _customerService.DeleteCustomerAsync(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Đã xóa thông Tin khách hàng thành công";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không thể xóa thông tin khách hàng";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}