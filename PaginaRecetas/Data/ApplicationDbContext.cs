using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PaginaRecetas.Data.ApplicationDbContext;

namespace PaginaRecetas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Para AspNetRoles
        builder.Entity<IdentityRole>(entity =>
        {
            entity.Property(r => r.Id).HasColumnType("varchar(255)");
            entity.Property(r => r.NormalizedName).HasColumnType("varchar(255)");
        });

        // Para AspNetUsers
        builder.Entity<IdentityUser>(entity =>
        {
            entity.Property(u => u.Id).HasColumnType("varchar(255)");
            entity.Property(u => u.NormalizedUserName).HasColumnType("varchar(255)");
            entity.Property(u => u.NormalizedEmail).HasColumnType("varchar(255)");
        });

        // Para AspNetRoleClaims
        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.Property(rc => rc.RoleId).HasColumnType("varchar(255)");
        });

        //para AspNetUserClaims
        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.Property(uc => uc.UserId).HasColumnType("varchar(255)");
        });

       

        builder.Entity<IdentityUser>(b =>
        {
            b.Property(u => u.NormalizedEmail).HasMaxLength(256);
        });
    }



    public class recetas
    {
        [Key]
        public int Id { get; set; }
        public string titulo { get; set; }
        public string Descripcion { get; set; }
        public int usuarios_id { get; set; }
        [Column(TypeName = "text")]
        public string ingredientes { get; set; }
        [Column(TypeName = "text")]
        public string instrucciones { get; set; }
        public int region_nombre { get; set; }
        public int tipo_nombre { get; set; }
        public int complejidad_nivel { get; set; }
        public int tiempo_duracion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string imagen_portada { get; set; }
        public int visitas { get; set; }
    }

    public class visitas
    {
        [Key]
        public int id { get; set; }
        public int num_visitas { get; set; }
        public DateTime Fecha_visitas { get; set; }
    }

    public class region
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

    }

    public class tipo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

    }

    public class complejidad
    {
        [Key]
        public int id { get; set; }
        public string nivel { get; set; }

    }

    public class tiempo
    {
        [Key]
        public int id { get; set; }
        public string ranngo { get; set; }
    }

    public class reportes_recetas
    {
        [Key]
        public int id { get; set; }
        public int recetas_id { get; set; }
        public int motivo {  get; set; }
        public DateTime fecha_reporte {  get; set; }
        [Column(TypeName = "TINYINT(1)")]
        public bool estatus { get; set; }
    }

    public class motivo_receta
    {
        [Key]
        public int id { get; set; }
        public string motivos {  get; set; }
    }

    public class estatus_reporte 
    {
        [Key]
        [Column(TypeName = "TINYINT(1)")]
        public bool id { get; set; }
        public string nombre { get; set; }

    }

    public class reportes_comentarios 
    {
        [Key]
        public int id { get; set; }
        public int comentario_id { get; set; }
        public int motivo { get; set; }
        public DateTime fecha_reporte { get; set; }
        [Column(TypeName = "TINYINT(1)")]
        public bool estatus { get; set; }
    }

    public class motivos_comentarios 
    {
        [Key]
        public int id { get; set; }
        public string motivos { get; set; }
    }

    public class comentarios 
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "text")]
        public string contenido { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public DateTime fecha_comentario {  get; set; }

    }

    public class recetas_favoritas 
    {
        [Key]
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get;set; }
        public DateTime fecha_aguardado { get; set; }
    }

    public class recetas_guardadas 
    {
        [Key]
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public DateTime fecha_guardado { get; set; }
    }

    public class valoraciones 
    {
        [Key]
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public string Fecha_valoracion {  get; set; }
    }

    public class usuarios 
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
        public string contraseña { get; set; }
    }

    public class usuarios_roles 
    {
        [Key]
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int rol_id { get; set; }
    }

    public class rol 
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class roles_permisos 
    {
        [Key]
        public int id { get; set; }
        public int rol_id { get; set; }
        public int permiso_id { get; set; }
    }

    public class  permisos 
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        [MaxLength(255)]
        public override string Id { get; set; }
    }


    public DbSet<recetas> receta { get; set; }
    public DbSet<visitas> visita { get; set; }
    public DbSet<region> regiones { get; set; }
    public DbSet<complejidad> complejidades { get; set; }
    public DbSet<tipo> tipos { get; set; }
    public DbSet<tiempo> tiempos { get; set; }
    public DbSet<motivo_receta> motivo_Recetas { get; set; }
    public DbSet<reportes_recetas> reporte_Recetas { get; set; }
    public DbSet<estatus_reporte> estatus_Reportes { get; set; }
    public DbSet<reportes_comentarios> reportes_Comentarios { get; set; }
    public DbSet<motivos_comentarios> motivo_comentarios { get; set; }
    public DbSet<recetas_favoritas> recetas_Favoritas { get; set; }
    public DbSet<recetas_guardadas> recetas_Guardadas { get; set; }
    public DbSet<valoraciones> Valoraciones { get; set; }
    public DbSet<usuarios> usuario { get; set; }
    public DbSet<comentarios> comentario {  get; set; }
    public DbSet<usuarios_roles> usuarios_Roles { get; set; }
    public DbSet<rol> rols { get; set; }
    public DbSet<roles_permisos> roles_Permisos { get; set; }
    public DbSet<permisos> permiso { get; set; }

}


