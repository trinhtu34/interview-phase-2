using System.ComponentModel.DataAnnotations;

namespace Customer_Management_Frontend.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = null!;
        
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateOnly? BirthDay { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = null!;
        
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }

    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = null!;
        
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateOnly? BirthDay { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = null!;
        
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }
}