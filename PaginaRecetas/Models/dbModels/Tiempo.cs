using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("tiempo")]
[Index("Rango", Name = "UQ__tiempo__0506009D4497A278", IsUnique = true)]
public partial class Tiempo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("rango")]
    [StringLength(25)]
    [Unicode(false)]
    public string Rango { get; set; } = null!;

    [InverseProperty("RangoTiempoNavigation")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
