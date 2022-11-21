using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string? ReviewComment { get; set; }

    public int? Ratings { get; set; }

    public DateTime RatingDate { get; set; }

    public int? UserId { get; set; }

    public string? NonUser { get; set; }

    public int? UserLike { get; set; }

    public int? UserDislike { get; set; }

    public short? IsEnabled { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User? User { get; set; }
}
