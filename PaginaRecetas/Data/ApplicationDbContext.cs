using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaRecetas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public class recetas
    {
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
        public int id { get; set; }
        public int num_visitas { get; set; }
        public DateTime Fecha_visitas { get; set; }
    }

    public class region
    {
        public int id { get; set; }
        public string nombre { get; set; }

    }

    public class tipo
    {
        public int id { get; set; }
        public string nombre { get; set; }

    }

    public class complejidad
    {
        public int id { get; set; }
        public string nivel { get; set; }

    }

    public class tiempo
    {
        public int id { get; set; }
        public string ranngo { get; set; }
    }

    public class reportes_recetas
    {
        public int id { get; set; }
        public int recetas_id { get; set; }
        public int motivo {  get; set; }
        public DateTime fecha_reporte {  get; set; }
        public bool estatus { get; set; }
    }

    public class motivo_receta
    {
        public int id { get; set; }
        public string motivos {  get; set; }
    }

    public class estatus_reporte 
    {
        public int id { get; set; }
        public string nombre { get; set; }

    }

    public class reportes_comentarios 
    {
        public int id { get; set; }
        public int comentario_id { get; set; }
        public int motivo { get; set; }
        public DateTime fecha_reporte { get; set; }
        public bool estatus { get; set; }
    }

    public class motivos_comentarios 
    {
        public int id { get; set; }
        public string motivos { get; set; }
    }

    public class comentarios 
    {
        public int id { get; set; }
        [Column(TypeName = "text")]
        public string contenido { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public DateTime fecha_comentario {  get; set; }

    }

    public class recetas_favoritas 
    {
        public int usuario_id { get; set; }
        public int receta_id { get;set; }
        public DateTime fecha_aguardado { get; set; }
    }

    public class recetas_guardadas 
    {
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public DateTime fecha_guardado { get; set; }
    }

    public class valoraciones 
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int receta_id { get; set; }
        public string Fecha_valoracion {  get; set; }
    }

    public class usuarios 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
        public string contraseña { get; set; }
    }

    public class usuarios_roles 
    {
        public int usuario_id { get; set; }
        public int rol_id { get; set; }
    }

    public class rol 
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class roles_permisos 
    {
        public int rol_id { get; set; }
        public int permiso_id { get; set; }
    }

    public class  permisos 
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}


