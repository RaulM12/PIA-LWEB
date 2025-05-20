using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("usuarios")]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("fecha_registro")]
    public DateOnly FechaRegistro { get; set; }

    [Column("contraseña")]
    [StringLength(10)]
    [Unicode(false)]
    public string Contraseña { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    [InverseProperty("Usuario")]
    public virtual ICollection<ValoracionReceta> ValoracionReceta { get; set; } = new List<ValoracionReceta>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("UsuariosNavigation")]
    public virtual ICollection<Receta> Receta1 { get; set; } = new List<Receta>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Usuarios")]
    public virtual ICollection<Receta> RecetaNavigation { get; set; } = new List<Receta>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Usuarios")]
    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
