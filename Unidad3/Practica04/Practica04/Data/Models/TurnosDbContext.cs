﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica04.Data.Models;

public partial class TurnosDbContext : DbContext
{
    public TurnosDbContext(DbContextOptions<TurnosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDetallesPresupuesto> TDetallesPresupuestos { get; set; }

    public virtual DbSet<TPresupuesto> TPresupuestos { get; set; }

    public virtual DbSet<TProducto> TProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDetallesPresupuesto>(entity =>
        {
            entity.HasKey(e => new { e.IdDetalle, e.IdPresupuesto }).HasName("PK_Detalles_Presupuesto");

            entity.ToTable("T_Detalles_Presupuesto");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.IdPresupuesto).HasColumnName("id_presupuesto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdPresupuestoNavigation).WithMany(p => p.TDetallesPresupuestos)
                .HasForeignKey(d => d.IdPresupuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalles_Presupuesto_T_Presupuestos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TDetallesPresupuestos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalles_Presupuesto_T_Productos");
        });

        modelBuilder.Entity<TPresupuesto>(entity =>
        {
            entity.ToTable("T_Presupuestos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cliente)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Vigencia)
                .HasDefaultValue(2)
                .HasColumnName("vigencia");
        });

        modelBuilder.Entity<TProducto>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("T_Productos");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.EstaActivo).HasColumnName("esta_activo");
            entity.Property(e => e.NProducto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("n_producto");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}