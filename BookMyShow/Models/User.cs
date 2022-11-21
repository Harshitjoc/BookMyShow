using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailId { get; set; }

    public int? Age { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public int LoginId { get; set; }

    public short? IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Login Login { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<UserRoleMap> UserRoleMaps { get; } = new List<UserRoleMap>();
}
