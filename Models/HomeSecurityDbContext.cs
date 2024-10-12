using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CameraStreamingAPI.Models;

public partial class HomeSecurityDbContext : DbContext
{
    public HomeSecurityDbContext()
    {
    }

    public HomeSecurityDbContext(DbContextOptions<HomeSecurityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Stream> Streams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HomeSecurityDB;User Id=SA;Password=10200053Rbm;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Devices__3213E83F36361329");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("deviceName");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deviceType");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Devices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Devices__userId__3C69FB99");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phones__3213E83F77A1436C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Phones)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Phones__userId__398D8EEE");
        });

        modelBuilder.Entity<Stream>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Streams__3213E83FE7618905");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeviceId).HasColumnName("deviceId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StreamUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("streamUrl");

            entity.HasOne(d => d.Device).WithMany(p => p.Streams)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Streams__deviceI__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F9721A190");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
