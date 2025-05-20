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

    }
}

