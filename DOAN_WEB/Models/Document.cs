using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Document
{
    public int IdDoc { get; set; }

    public string? DocType { get; set; }

    public string? DocName { get; set; }

    public DateTime? DocDate { get; set; }

    public double? DocSize { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
