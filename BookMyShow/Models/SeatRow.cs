using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class SeatRow
{
    public int Id { get; set; }

    public string RowName { get; set; } = null!;

    public int NoOfSeats { get; set; }

    public int SeatId { get; set; }

    public short IsBooked { get; set; }

    public short? IsEnabled { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual ICollection<SeatShowMap> SeatShowMaps { get; } = new List<SeatShowMap>();
}
