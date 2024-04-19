using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Calendar
{
    public int IdCal { get; set; }

    public string? CalName { get; set; }

    public string? CalType { get; set; }

    public int IdUser { get; set; }

    public DateTime? CalDate { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
