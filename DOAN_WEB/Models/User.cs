using System;
using System.Collections.Generic;

namespace DOAN_WEB.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int? Idcompany { get; set; }

    public int? LineManager { get; set; }

    public byte MaCv { get; set; }

    public string? UserName { get; set; }

    public string? EmailUser { get; set; }

    public string? PersionalEmail { get; set; }

    public string? PasswordUser { get; set; }

    public string? ImgUser { get; set; }

    public bool? Gender { get; set; }

    public double? SalaryCurrent { get; set; }

    public DateTime? Dob { get; set; }

    public string? PhoneNumber { get; set; }

    public string? SecondPhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? BankName { get; set; }

    public string? AccountNumber { get; set; }

    public bool? Status { get; set; }

    public bool? IsDelete { get; set; }

    public string? Country { get; set; }

    public DateTime? Startday { get; set; }

    public string? JobTitle { get; set; }

    public bool? JobType { get; set; }

    public string? Frequency { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Company? IdcompanyNavigation { get; set; }

    public virtual ICollection<User> InverseLineManagerNavigation { get; set; } = new List<User>();

    public virtual User? LineManagerNavigation { get; set; }

    public virtual ChucVu MaCvNavigation { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

    public virtual ICollection<Wahome> Wahomes { get; set; } = new List<Wahome>();
}
