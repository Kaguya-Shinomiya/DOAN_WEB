using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOAN_WEB.Models;

public partial class MhDaWContext : DbContext
{
    public MhDaWContext()
    {
    }

    public MhDaWContext(DbContextOptions<MhDaWContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserTeam> UserTeams { get; set; }

    public virtual DbSet<Wahome> Wahomes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ASB6N02\\QUANGBAO;Database=MH_DA_W;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.IdCal).HasName("PK__Calendar__2BF9F61C852A755F");

            entity.ToTable("Calendar");

            entity.Property(e => e.IdCal)
                .ValueGeneratedNever()
                .HasColumnName("ID_Cal");
            entity.Property(e => e.CalDate)
                .HasColumnType("datetime")
                .HasColumnName("Cal_Date");
            entity.Property(e => e.CalName)
                .HasMaxLength(100)
                .HasColumnName("Cal_Name");
            entity.Property(e => e.CalType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cal_Type");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calendar__ID_Use__7EF6D905");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__Chuc_Vu__27258E76C301A601");

            entity.ToTable("Chuc_Vu");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(50)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Idcompany).HasName("PK__Company__9A030B76AD4D8C69");

            entity.ToTable("Company");

            entity.Property(e => e.Idcompany)
                .ValueGeneratedNever()
                .HasColumnName("IDCompany");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("Address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("Address_2");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("Company_Name");
            entity.Property(e => e.CompanyNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IncorporationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Incorporation_Date");
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .HasColumnName("Post_Code");
            entity.Property(e => e.VatNumber)
                .HasMaxLength(20)
                .HasColumnName("Vat_Number");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.IdDoc).HasName("PK__Document__2BBC7E806E13BE34");

            entity.ToTable("Document");

            entity.Property(e => e.IdDoc)
                .ValueGeneratedNever()
                .HasColumnName("ID_Doc");
            entity.Property(e => e.DocDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("Doc_Date");
            entity.Property(e => e.DocName)
                .HasMaxLength(100)
                .HasColumnName("Doc_Name");
            entity.Property(e => e.DocSize).HasColumnName("Doc_Size");
            entity.Property(e => e.DocType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doc_Type");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__ID_Use__7E02B4CC");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Role__43DCD32DAF5443D5");

            entity.ToTable("Role");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("ID_Role");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IdTeam).HasName("PK__Team__D65894386DEF8F39");

            entity.ToTable("Team");

            entity.Property(e => e.IdTeam)
                .ValueGeneratedNever()
                .HasColumnName("ID_Team");
            entity.Property(e => e.TeamName)
                .HasMaxLength(100)
                .HasColumnName("Team_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__ED4DE442A69FE0B3");

            entity.ToTable("User");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("ID_User");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Bank_Name");
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Dob)
                .HasColumnType("smalldatetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmailUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Email_User");
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.Idcompany).HasColumnName("IDCompany");
            entity.Property(e => e.ImgUser)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Img_User");
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .HasColumnName("Job_Title");
            entity.Property(e => e.JobType).HasColumnName("Job_Type");
            entity.Property(e => e.LineManager).HasColumnName("Line_Manager");
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Password_User");
            entity.Property(e => e.PersionalEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Persional_Email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phone_Number");
            entity.Property(e => e.SalaryCurrent).HasColumnName("Salary_Current");
            entity.Property(e => e.SecondPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Second_Phone_Number");
            entity.Property(e => e.Startday).HasColumnType("smalldatetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("User_Name");

            entity.HasOne(d => d.IdcompanyNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idcompany)
                .HasConstraintName("FK__User__IDCompany__05A3D694");

            entity.HasOne(d => d.LineManagerNavigation).WithMany(p => p.InverseLineManagerNavigation)
                .HasForeignKey(d => d.LineManager)
                .HasConstraintName("FK__User__Line_Manag__01D345B0");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MaCv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__MaCV__02C769E9");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.IdRole, e.IdUser }).HasName("PK__User_Rol__7D080D69F90C4768");

            entity.ToTable("User_Role");

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.IsAccept1).HasColumnName("isAccept1");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Role__ID_Ro__03BB8E22");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Role__ID_Us__7D0E9093");
        });

        modelBuilder.Entity<UserTeam>(entity =>
        {
            entity.HasKey(e => new { e.IdTeam, e.IdUser }).HasName("PK__User_Tea__E88C4A7C6BD5AEF4");

            entity.ToTable("User_Team");

            entity.Property(e => e.IdTeam).HasColumnName("ID_Team");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.IdTeamNavigation).WithMany(p => p.UserTeams)
                .HasForeignKey(d => d.IdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Team__ID_Te__04AFB25B");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserTeams)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Team__ID_Us__00DF2177");
        });

        modelBuilder.Entity<Wahome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WAHome__3214EC2766529A5D");

            entity.ToTable("WAHome");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateWah)
                .HasColumnType("smalldatetime")
                .HasColumnName("Date_WAH");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Wahomes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WAHome__ID_User__7FEAFD3E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
