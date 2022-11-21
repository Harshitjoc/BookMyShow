using System;
using System.Collections.Generic;

namespace BookMyShow.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RolePermissionMap> RolePermissionMaps { get; } = new List<RolePermissionMap>();

    public virtual ICollection<UserRoleMap> UserRoleMaps { get; } = new List<UserRoleMap>();
}
