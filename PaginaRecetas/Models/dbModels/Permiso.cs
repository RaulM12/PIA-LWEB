using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("permisos")]
public partial class Permiso
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("PermisoId")]
    [InverseProperty("Permisos")]
    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
