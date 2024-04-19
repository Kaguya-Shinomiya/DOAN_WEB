using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class Company
{
    public int Idcompany { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyNumber { get; set; }

    public DateTime? IncorporationDate { get; set; }

    public string? VatNumber { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PostCode { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
