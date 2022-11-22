using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Show
{
    public int Id { get; set; }

    public int ShowtimeId { get; set; }

    public int ScreenId { get; set; }

    public int TheatreId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Screen Screen { get; set; } = null!;

    public virtual ICollection<SeatShowMap> SeatShowMaps { get; } = new List<SeatShowMap>();

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual Theatre Theatre { get; set; } = null!;
}
