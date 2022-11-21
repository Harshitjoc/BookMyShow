using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Screen
{
    public int Id { get; set; }

    public int? TheatreId { get; set; }

    public string ScreenType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<Seat> Seats { get; } = new List<Seat>();

    public virtual ICollection<Show> Shows { get; } = new List<Show>();

    public virtual Theatre? Theatre { get; set; }
}
