using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Theatre
{
    public int Id { get; set; }

    public string TheatreName { get; set; } = null!;

    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public int NoOfScreens { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Screen> Screens { get; } = new List<Screen>();

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
