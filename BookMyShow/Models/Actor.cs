using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Actor
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<MovieActorMap> MovieActorMaps { get; } = new List<MovieActorMap>();
}
