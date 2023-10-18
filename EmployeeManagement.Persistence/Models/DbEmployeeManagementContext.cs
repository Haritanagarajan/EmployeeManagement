using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Models;

public partial class DbEmployeeManagementContext : DbContext
{
    public DbEmployeeManagementContext()
    {
    }

    public DbEmployeeManagementContext(DbContextOptions<DbEmployeeManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    public virtual DbSet<SalaryMaster> SalaryMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-54BLE96\\SQLEXPRESS2019;Database=DbEmployeeManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED0538138E");

            entity.ToTable("DepartmentMaster");

            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD60DEE73CBDFB");

            entity.ToTable("DesignationMaster");

            entity.Property(e => e.DesignationName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.DesignationMasters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Designati__Depar__38996AB5");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F1165B3079F");

            entity.ToTable("EmployeeMaster");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__EmployeeM__Depar__44FF419A");

            entity.HasOne(d => d.Designation).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__EmployeeM__Desig__45F365D3");
        });

        modelBuilder.Entity<SalaryMaster>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__SalaryMa__4BE20457D104C363");

            entity.ToTable("SalaryMaster");

            entity.HasOne(d => d.Department).WithMany(p => p.SalaryMasters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__SalaryMas__Depar__3B75D760");

            entity.HasOne(d => d.Designation).WithMany(p => p.SalaryMasters)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__SalaryMas__Desig__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
