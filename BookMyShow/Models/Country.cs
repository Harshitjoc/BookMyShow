using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short? IsEnabled { get; set; }

    public virtual ICollection<State> States { get; } = new List<State>();
}
