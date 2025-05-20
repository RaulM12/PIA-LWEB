using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("reportes_recetas")]
public partial class ReportesReceta
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("receta_id")]
    public int RecetaId { get; set; }

    [Column("motivo_reporte", TypeName = "text")]
    public string MotivoReporte { get; set; } = null!;

    [Column("fecha_reporte")]
    public DateOnly FechaReporte { get; set; }

    [Column("estatus_id")]
    public int EstatusId { get; set; }

    [ForeignKey("EstatusId")]
    [InverseProperty("ReportesReceta")]
    public virtual EstatusReporte Estatus { get; set; } = null!;

    [ForeignKey("RecetaId")]
    [InverseProperty("ReportesReceta")]
    public virtual Receta Receta { get; set; } = null!;
}
