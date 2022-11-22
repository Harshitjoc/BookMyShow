using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int? BookingId { get; set; }

    public string Class { get; set; } = null!;

    public int Price { get; set; }

    public int? CouponId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Coupon? Coupon { get; set; }
}
