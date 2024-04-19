using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class UserRole
{
    public int IdRole { get; set; }

    public bool? IsAccept { get; set; }

    public bool? IsAccept1 { get; set; }

    public int IdUser { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
