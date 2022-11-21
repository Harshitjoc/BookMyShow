using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string? Permissions { get; set; }

    public virtual ICollection<RolePermissionMap> RolePermissionMaps { get; } = new List<RolePermissionMap>();
}
