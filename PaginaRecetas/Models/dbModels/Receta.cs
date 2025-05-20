using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("recetas")]
public partial class Receta
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(25)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(300)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Column("ingredientes", TypeName = "text")]
    public string Ingredientes { get; set; } = null!;

    [Column("region_nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string RegionNombre { get; set; } = null!;

    [Column("tipo_nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string TipoNombre { get; set; } = null!;

    [Column("complejidad_nivel")]
    [StringLength(25)]
    [Unicode(false)]
    public string ComplejidadNivel { get; set; } = null!;

    [Column("rango_tiempo")]
    [StringLength(25)]
    [Unicode(false)]
    public string RangoTiempo { get; set; } = null!;

    [Column("fecha_creacion", TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [Column("imagen_portada")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ImagenPortada { get; set; }

    [Column("visitas")]
    public int? Visitas { get; set; }

    [Column("estatus_id")]
    public int EstatusId { get; set; }

    [InverseProperty("Receta")]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [ForeignKey("ComplejidadNivel")]
    [InverseProperty("Receta")]
    public virtual Complejidad ComplejidadNivelNavigation { get; set; } = null!;

    [ForeignKey("EstatusId")]
    [InverseProperty("Receta")]
    public virtual EstatusReporte Estatus { get; set; } = null!;

    [ForeignKey("RangoTiempo")]
    [InverseProperty("Receta")]
    public virtual Tiempo RangoTiempoNavigation { get; set; } = null!;

    [ForeignKey("RegionNombre")]
    [InverseProperty("Receta")]
    public virtual Region RegionNombreNavigation { get; set; } = null!;

    [InverseProperty("Receta")]
    public virtual ICollection<ReportesReceta> ReportesReceta { get; set; } = new List<ReportesReceta>();

    [ForeignKey("TipoNombre")]
    [InverseProperty("Receta")]
    public virtual Tipo TipoNombreNavigation { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Receta")]
    public virtual Usuario Usuario { get; set; } = null!;

    [InverseProperty("Receta")]
    public virtual ICollection<ValoracionReceta> ValoracionReceta { get; set; } = new List<ValoracionReceta>();

    [ForeignKey("RecetaId")]
    [InverseProperty("RecetaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [ForeignKey("RecetaId")]
    [InverseProperty("Receta1")]
    public virtual ICollection<Usuario> UsuariosNavigation { get; set; } = new List<Usuario>();
}
