using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StateId { get; set; }

    public short? IsEnabled { get; set; }

    public virtual State State { get; set; } = null!;

    public virtual ICollection<Theatre> Theatres { get; } = new List<Theatre>();
}
