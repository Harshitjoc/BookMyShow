using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string TransactionType { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

    public DateTime TransactionDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
