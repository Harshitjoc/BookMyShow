using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Coupon
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Discount { get; set; }

    public DateTime? Validtill { get; set; }

    public short? IsEnabled { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
