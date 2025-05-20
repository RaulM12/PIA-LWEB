using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

public partial class BdPrecetasContext : DbContext
{
    public BdPrecetasContext()
    {
    }

    public BdPrecetasContext(DbContextOptions<BdPrecetasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Complejidad> Complejidads { get; set; }

    public virtual DbSet<EstatusReporte> EstatusReportes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<ReportesComentario> ReportesComentarios { get; set; }

    public virtual DbSet<ReportesReceta> ReportesRecetas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tiempo> Tiempos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ValoracionReceta> ValoracionRecetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=BD_PRecetas;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comentar__3213E83F432299F6");

            entity.HasOne(d => d.Receta).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comentari__recet__6D0D32F4");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comentari__usuar__6C190EBB");
        });

        modelBuilder.Entity<Complejidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__compleji__3213E83F227FA4CF");
        });

        modelBuilder.Entity<EstatusReporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estatus___3213E83FCFDFA416");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permisos__3213E83F91993429");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__recetas__3213E83F73B6A0C7");

            entity.Property(e => e.Visitas).HasDefaultValue(0);

            entity.HasOne(d => d.ComplejidadNivelNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nivel)
                .HasForeignKey(d => d.ComplejidadNivel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__complej__6754599E");

            entity.HasOne(d => d.Estatus).WithMany(p => p.Receta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__estatus__693CA210");

            entity.HasOne(d => d.RangoTiempoNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Rango)
                .HasForeignKey(d => d.RangoTiempo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__rango_t__68487DD7");

            entity.HasOne(d => d.RegionNombreNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nombre)
                .HasForeignKey(d => d.RegionNombre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__region___656C112C");

            entity.HasOne(d => d.TipoNombreNavigation).WithMany(p => p.Receta)
                .HasPrincipalKey(p => p.Nombre)
                .HasForeignKey(d => d.TipoNombre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__tipo_no__66603565");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Receta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recetas__usuario__6477ECF3");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__region__3213E83F54C1C73C");
        });

        modelBuilder.Entity<ReportesComentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reportes__3213E83F142F5500");

            entity.HasOne(d => d.Comentario).WithMany(p => p.ReportesComentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___comen__73BA3083");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.ReportesComentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___estat__74AE54BC");
        });

        modelBuilder.Entity<ReportesReceta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reportes__3213E83FBCA7C5A1");

            entity.HasOne(d => d.Estatus).WithMany(p => p.ReportesReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___estat__787EE5A0");

            entity.HasOne(d => d.Receta).WithMany(p => p.ReportesReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reportes___recet__778AC167");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83FE6604BB0");

            entity.HasMany(d => d.Permisos).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__roles_per__permi__4F7CD00D"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__roles_per__rol_i__4E88ABD4"),
                    j =>
                    {
                        j.HasKey("RolId", "PermisoId").HasName("PK__roles_pe__0939B2DFA368839A");
                        j.ToTable("roles_permisos");
                        j.IndexerProperty<int>("RolId").HasColumnName("rol_id");
                        j.IndexerProperty<int>("PermisoId").HasColumnName("permiso_id");
                    });
        });

        modelBuilder.Entity<Tiempo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tiempo__3213E83F7723ED9F");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipo__3213E83F218B9CA3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F592D27FB");

            entity.HasMany(d => d.Receta1).WithMany(p => p.UsuariosNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "RecetasGuardada",
                    r => r.HasOne<Receta>().WithMany()
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__recetas_g__recet__7C4F7684"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__recetas_g__usuar__7B5B524B"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RecetaId").HasName("PK__recetas___6A6B78C41E775F99");
                        j.ToTable("recetas_guardadas");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<int>("RecetaId").HasColumnName("receta_id");
                    });

            entity.HasMany(d => d.RecetaNavigation).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "RecetasFavorita",
                    r => r.HasOne<Receta>().WithMany()
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__recetas_f__recet__00200768"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__recetas_f__usuar__7F2BE32F"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RecetaId").HasName("PK__recetas___6A6B78C446CCF14D");
                        j.ToTable("recetas_favoritas");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<int>("RecetaId").HasColumnName("receta_id");
                    });

            entity.HasMany(d => d.Rols).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosRole",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__usuarios___rol_i__4BAC3F29"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__usuarios___usuar__4AB81AF0"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RolId").HasName("PK__usuarios__0224FCEB4F0C4226");
                        j.ToTable("usuarios_roles");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<int>("RolId").HasColumnName("rol_id");
                    });
        });

        modelBuilder.Entity<ValoracionReceta>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.RecetaId }).HasName("PK__valoraci__6A6B78C4F6CD87C9");

            entity.HasOne(d => d.Receta).WithMany(p => p.ValoracionReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__valoracio__recet__70DDC3D8");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ValoracionReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__valoracio__usuar__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
