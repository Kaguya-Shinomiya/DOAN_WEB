using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class ChucVu
{
    public byte MaCv { get; set; }

    public string? TenCv { get; set; }

    public byte? Permission { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
