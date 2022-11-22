using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class SeatPrice
{
    public int Id { get; set; }

    public string Price { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();
}
