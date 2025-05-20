using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("complejidad")]
[Index("Nivel", Name = "UQ__compleji__45ACCC64F8E389D1", IsUnique = true)]
public partial class Complejidad
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nivel")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nivel { get; set; } = null!;

    [InverseProperty("ComplejidadNivelNavigation")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
