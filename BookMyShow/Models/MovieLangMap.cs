using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class MovieLangMap
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
