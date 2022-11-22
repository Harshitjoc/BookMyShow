using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Seat
{
    public int Id { get; set; }

    public string? SeatType { get; set; }

    public int ScreenId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short IsEnabled { get; set; }

    public int SeatPriceId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Screen Screen { get; set; } = null!;

    public virtual SeatPrice SeatPrice { get; set; } = null!;

    public virtual ICollection<SeatRow> SeatRows { get; } = new List<SeatRow>();
}
