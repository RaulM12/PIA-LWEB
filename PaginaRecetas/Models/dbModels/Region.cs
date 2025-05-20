using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("region")]
[Index("Nombre", Name = "UQ__region__72AFBCC6806563C7", IsUnique = true)]
public partial class Region
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("RegionNombreNavigation")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
