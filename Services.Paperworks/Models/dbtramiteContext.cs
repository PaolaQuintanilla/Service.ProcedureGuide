using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Services.Paperworks.Models
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

        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Paperwork> Paperwork { get; set; }
        public virtual DbSet<Paperworkreception> Paperworkreception { get; set; }
        public virtual DbSet<Requirement> Requirement { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<User> User { get; set; }

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
            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Paperwork>(entity =>
            {
                entity.HasIndex(e => e.FacultyId)
                    .HasName("fk_PaperWork_Faculty1_idx");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Paperwork)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PaperWork_Faculty1");
            });

            modelBuilder.Entity<Paperworkreception>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.HasIndex(e => e.PaperWorkId)
                    .HasName("fk_Requirement_PaperWork1_idx");

                entity.HasIndex(e => e.PaperWorkReceptionId)
                    .HasName("fk_Requirement_PaperWorkReception1_idx");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.PaperWork)
                    .WithMany(p => p.Requirement)
                    .HasForeignKey(d => d.PaperWorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Requirement_PaperWork1");

                entity.HasOne(d => d.PaperWorkReception)
                    .WithMany(p => p.Requirement)
                    .HasForeignKey(d => d.PaperWorkReceptionId)
                    .HasConstraintName("fk_Requirement_PaperWorkReception1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RolId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RolId)
                    .HasName("fk_User_Rol1_idx");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_Rol1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
