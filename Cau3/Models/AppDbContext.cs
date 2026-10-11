using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SunriseHomestay.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LTTQ_QuanLyLoaiPhong;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiPhon__730A5759F0A26C8F");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.GiaMoiDem).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__Phong__20BD5E5BEEA3F270");

            entity.ToTable("Phong");

            entity.HasIndex(e => e.SoPhong, "UQ__Phong__7C736CA11A1A5577").IsUnique();

            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.SoPhong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(20)
                .HasDefaultValue("Trống");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
