using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class UserTeam
{
    public int IdTeam { get; set; }

    public int IdUser { get; set; }

    public string? Title { get; set; }

    public virtual Team IdTeamNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
