using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Team
{
    public int IdTeam { get; set; }

    public string? TeamName { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
}
