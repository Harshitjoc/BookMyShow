using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class UserRoleMap
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public int RolesId { get; set; }

    public virtual Role Roles { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
