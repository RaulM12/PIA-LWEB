using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("rol")]
public partial class Rol
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("RolId")]
    [InverseProperty("Rols")]
    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    [ForeignKey("RolId")]
    [InverseProperty("Rols")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
