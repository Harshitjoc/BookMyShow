using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class SeatShowMap
{
    public int Id { get; set; }

    public int SeatRowsId { get; set; }

    public int ShowsId { get; set; }

    public virtual SeatRow SeatRows { get; set; } = null!;

    public virtual Show Shows { get; set; } = null!;
}
