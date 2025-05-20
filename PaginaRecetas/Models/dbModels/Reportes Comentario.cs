using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("reportes_comentarios")]
public partial class ReportesComentario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("comentario_id")]
    public int ComentarioId { get; set; }

    [Column("motivo", TypeName = "text")]
    public string Motivo { get; set; } = null!;

    [Column("fecha_reporte")]
    public DateOnly FechaReporte { get; set; }

    [Column("estatus")]
    public int Estatus { get; set; }

    [ForeignKey("ComentarioId")]
    [InverseProperty("ReportesComentarios")]
    public virtual Comentario Comentario { get; set; } = null!;

    [ForeignKey("Estatus")]
    [InverseProperty("ReportesComentarios")]
    public virtual EstatusReporte EstatusNavigation { get; set; } = null!;
}
