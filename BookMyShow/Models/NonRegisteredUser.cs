using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class NonRegisteredUser
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int PhoneNo { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
