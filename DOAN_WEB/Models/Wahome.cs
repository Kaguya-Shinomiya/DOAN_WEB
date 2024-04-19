using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Wahome
{
    public int Id { get; set; }

    public DateTime? DateWah { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
