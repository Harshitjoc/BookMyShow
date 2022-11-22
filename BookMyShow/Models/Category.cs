﻿namespace BookMyShow.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MovieCategoryMap> MovieCategoryMaps { get; } = new List<MovieCategoryMap>();
}
