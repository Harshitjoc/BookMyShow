using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float Duration { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string CertificateType { get; set; } = null!;

    public string About { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public short IsDeleted { get; set; }

    public short IsEnabled { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<MovieActorMap> MovieActorMaps { get; } = new List<MovieActorMap>();

    public virtual ICollection<MovieCategoryMap> MovieCategoryMaps { get; } = new List<MovieCategoryMap>();

    public virtual ICollection<MovieLangMap> MovieLangMaps { get; } = new List<MovieLangMap>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Showtime> Showtimes { get; } = new List<Showtime>();
}
