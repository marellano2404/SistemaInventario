using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("RolesFuncionalidades", Schema = "Seguridad")]
    public partial class RolesFuncionalidades
    {
        [Key]
        public int Id { get; set; }
        public Guid? IdRol { get; set; }
        public Guid? IdFuncionalidad { get; set; }

        [ForeignKey(nameof(IdFuncionalidad))]
        [InverseProperty(nameof(Funcionalidades.RolesFuncionalidades))]
        public virtual Funcionalidades IdFuncionalidadNavigation { get; set; }
        [ForeignKey(nameof(IdRol))]
        [InverseProperty(nameof(Roles.RolesFuncionalidades))]
        public virtual Roles IdRolNavigation { get; set; }
    }
}
