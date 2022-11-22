using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class MovieCategoryMap
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int MovieId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
