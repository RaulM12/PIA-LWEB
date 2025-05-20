using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("estatus_reporte")]
public partial class EstatusReporte
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Estatus")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    [InverseProperty("EstatusNavigation")]
    public virtual ICollection<ReportesComentario> ReportesComentarios { get; set; } = new List<ReportesComentario>();

    [InverseProperty("Estatus")]
    public virtual ICollection<ReportesReceta> ReportesReceta { get; set; } = new List<ReportesReceta>();
}
