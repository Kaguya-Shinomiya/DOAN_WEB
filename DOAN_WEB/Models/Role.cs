using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? RoleName { get; set; }

    public bool? IsDelete { get; set; }

    public byte? Slide { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
