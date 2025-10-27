namespace Application.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly? BirthDay { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
    }

    public class CreateCustomerDTO
    {
        public string FullName { get; set; } = null!;
        public DateOnly? BirthDay { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
    }

    public class UpdateCustomerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly? BirthDay { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
    }
}
