using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Models;

public partial class AdminDashboardContext : DbContext
{
    public AdminDashboardContext()
    {
    }

    public AdminDashboardContext(DbContextOptions<AdminDashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Shoe> Shoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=admin_dashboard;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shoe>(entity =>
        {
            entity.HasKey(e => e.ShoesId);

            entity.ToTable("Shoe");

            entity.Property(e => e.ShoesId)
                .ValueGeneratedNever()
                .HasColumnName("shoes_id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("date")
                .HasColumnName("added_date");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
