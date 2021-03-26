﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Servicios.TramitesUmss.Models
{
    public partial class dbtramiteContext : DbContext
    {
        public dbtramiteContext()
        {
        }

        public dbtramiteContext(DbContextOptions<dbtramiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Requisito> Requisito { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tramite> Tramite { get; set; }
        public virtual DbSet<Tramiterequisito> Tramiterequisito { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ventanilla> Ventanilla { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Database=dbtramite;user=root;password=mysqlpao;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Requisito>(entity =>
            {
                entity.HasKey(e => new { e.IdPasos, e.UbicacionIdUbicacion })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UbicacionIdUbicacion)
                    .HasName("fk_Requisito_Ubicacion1_idx");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.UbicacionIdUbicacionNavigation)
                    .WithMany(p => p.Requisito)
                    .HasForeignKey(d => d.UbicacionIdUbicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Requisito_Ubicacion1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.HasKey(e => e.IdTramites)
                    .HasName("PRIMARY");

                entity.Property(e => e.Tramitescol).IsUnicode(false);
            });

            modelBuilder.Entity<Tramiterequisito>(entity =>
            {
                entity.HasKey(e => new { e.RequisitoIdPasos, e.RequisitoUbicacionIdUbicacion, e.TramiteIdTramites })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.TramiteIdTramites)
                    .HasName("fk_TramiteRequisito_Tramite1_idx");

                entity.HasOne(d => d.TramiteIdTramitesNavigation)
                    .WithMany(p => p.Tramiterequisito)
                    .HasForeignKey(d => d.TramiteIdTramites)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TramiteRequisito_Tramite1");

                entity.HasOne(d => d.Requisito)
                    .WithMany(p => p.Tramiterequisito)
                    .HasForeignKey(d => new { d.RequisitoIdPasos, d.RequisitoUbicacionIdUbicacion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TramiteRequisito_Requisito1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RolId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RolId)
                    .HasName("fk_User_Rol1_idx");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_Rol1");
            });

            modelBuilder.Entity<Ventanilla>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
