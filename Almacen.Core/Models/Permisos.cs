using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Permisos", Schema = "Seguridad")]
    public partial class Permisos
    {
        [Key]
        public int Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdRol { get; set; }

        [ForeignKey(nameof(IdRol))]
        [InverseProperty(nameof(Roles.Permisos))]
        public virtual Roles IdRolNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Usuarios.Permisos))]
        public virtual Usuarios IdUserNavigation { get; set; }
    }
}
