using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
