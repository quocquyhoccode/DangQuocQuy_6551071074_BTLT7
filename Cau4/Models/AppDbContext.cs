using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BacSi> BacSis { get; set; }

    public virtual DbSet<LichKham> LichKhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LTTQ_QuanLyLichKhamBenh;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BacSi>(entity =>
        {
            entity.HasKey(e => e.MaBs).HasName("PK__BacSi__2724759655456C90");

            entity.ToTable("BacSi");

            entity.Property(e => e.MaBs).HasColumnName("MaBS");
            entity.Property(e => e.ChuyenKhoa).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<LichKham>(entity =>
        {
            entity.HasKey(e => e.MaLich).HasName("PK__LichKham__728A9AE9451B3FE9");

            entity.ToTable("LichKham");

            entity.Property(e => e.MaBs).HasColumnName("MaBS");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenBenhNhan).HasMaxLength(100);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ khám");

            entity.HasOne(d => d.MaBsNavigation).WithMany(p => p.LichKhams)
                .HasForeignKey(d => d.MaBs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LichKham_BacSi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
