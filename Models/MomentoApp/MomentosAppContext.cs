using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.MomentoApp;

public partial class MomentosAppContext : DbContext
{
    public MomentosAppContext()
    {
    }

    public MomentosAppContext(DbContextOptions<MomentosAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentSub> CommentSubs { get; set; }

    public virtual DbSet<ExceptionLogs> Exceptions { get; set; }

    public virtual DbSet<FamConn> FamConns { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<PInstitution> PInstitutions { get; set; }

    public virtual DbSet<PRole> PRoles { get; set; }

    public virtual DbSet<PTarget> PTargets { get; set; }

    public virtual DbSet<PVisib> PVisibs { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<PublicationAudit> PublicationAudits { get; set; }

    public virtual DbSet<PublicationPicture> PublicationPictures { get; set; }

    public virtual DbSet<PublicationText> PublicationTexts { get; set; }

    public virtual DbSet<TargetUser> TargetUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAudit> UserAudits { get; set; }

    public virtual DbSet<UserInsti> UserInstis { get; set; }

    public virtual DbSet<UserPicture> UserPictures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=168.226.219.57,2424;Database=MomentosApp;User ID=sa;Password=Excel159753;Connection Timeout=600;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComment).HasName("PK__Comment__57C9AD584FD0A213");

            entity.ToTable("Comment");

            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Message).HasMaxLength(256);
        });

        modelBuilder.Entity<CommentSub>(entity =>
        {
            entity.HasKey(e => e.IdSubComment).HasName("PK__Comment___E5B021892EFA363E");

            entity.ToTable("Comment_Sub");

            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Message).HasMaxLength(256);
        });

        modelBuilder.Entity<ExceptionLogs>(entity =>
        {
            entity.HasKey(e => e.IdException).HasName("PK__Exceptio__0DDE5C82BFE1839D");

            entity.ToTable("Exception");

            entity.Property(e => e.Action).HasMaxLength(64);
            entity.Property(e => e.Controller).HasMaxLength(64);
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<FamConn>(entity =>
        {
            entity.HasKey(e => e.IdFamConn).HasName("PK__FamConn__17D88AB4A9C33ACC");

            entity.ToTable("FamConn");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC07424D18B6");
        });

        modelBuilder.Entity<PInstitution>(entity =>
        {
            entity.HasKey(e => e.IdInsti).HasName("PK__P_Instit__F69D899854C27698");

            entity.ToTable("P_Institution");

            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<PRole>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Roles__B4369054009CB1A0");

            entity.ToTable("P_Role");

            entity.Property(e => e.RoleName).HasMaxLength(64);
        });

        modelBuilder.Entity<PTarget>(entity =>
        {
            entity.HasKey(e => e.IdTarget).HasName("PK__P_Target__604C45F51393FE3B");

            entity.ToTable("P_Target");

            entity.Property(e => e.TargetType).HasMaxLength(64);
        });

        modelBuilder.Entity<PVisib>(entity =>
        {
            entity.HasKey(e => e.IdVisib).HasName("PK__P_Visib__58A5F8C0B159DF02");

            entity.ToTable("P_Visib");

            entity.Property(e => e.VisibName).HasMaxLength(64);
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.IdPublication).HasName("PK__Publicat__4744DC3A717F6FF7");

            entity.ToTable("Publication");
        });

        modelBuilder.Entity<PublicationAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicat__3214EC072C1FB942");

            entity.ToTable("Publication_Audit");

            entity.Property(e => e.AnnulDate)
                .HasDefaultValueSql("('19000101')")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CreationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ModifDate)
                .HasDefaultValueSql("('19000101')")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<PublicationPicture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publiaca__3214EC07F4481A9F");

            entity.ToTable("Publication_Picture");
        });

        modelBuilder.Entity<PublicationText>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicat__3214EC07C03DB1CB");

            entity.ToTable("Publication_Text");

            entity.Property(e => e.Text)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TargetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TargetUs__3214EC074BB6A3A4");

            entity.ToTable("TargetUser");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C926381294BB60");

            entity.ToTable("User");

            entity.Property(e => e.Cuil).HasMaxLength(11);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Mail).HasMaxLength(128);
            entity.Property(e => e.NameFull).HasMaxLength(64);
            entity.Property(e => e.Username).HasMaxLength(64);
        });

        modelBuilder.Entity<UserAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Au__3214EC072F5AF04B");

            entity.ToTable("User_Audit");

            entity.Property(e => e.AnnulDate)
                .HasDefaultValueSql("('19000101')")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ModifDate)
                .HasDefaultValueSql("('19000101')")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<UserInsti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Ins__3214EC077B61BC7A");

            entity.ToTable("User_Insti");
        });

        modelBuilder.Entity<UserPicture>(entity =>
        {
            entity.HasKey(e => e.IdUp).HasName("PK__Profile___B7703B2349659F43");

            entity.ToTable("User_Picture");

            entity.Property(e => e.IdUp).HasColumnName("IdUP");
            entity.Property(e => e.FileFormat).HasMaxLength(64);
            entity.Property(e => e.FileName).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
