using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Showtime
{
    public int Id { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int MovieId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short? IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
