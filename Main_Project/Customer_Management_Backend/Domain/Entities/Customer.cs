using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Customer : BaseEntity
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDay { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }
}
