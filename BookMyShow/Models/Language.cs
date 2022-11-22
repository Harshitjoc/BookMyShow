using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short? IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<MovieLangMap> MovieLangMaps { get; } = new List<MovieLangMap>();
}
