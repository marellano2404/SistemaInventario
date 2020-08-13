using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Roles", Schema = "Seguridad")]
    public partial class Roles
    {
        public Roles()
        {
            Permisos = new HashSet<Permisos>();
            RolesFuncionalidades = new HashSet<RolesFuncionalidades>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string RolName { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }

        [InverseProperty("IdRolNavigation")]
        public virtual ICollection<Permisos> Permisos { get; set; }
        [InverseProperty("IdRolNavigation")]
        public virtual ICollection<RolesFuncionalidades> RolesFuncionalidades { get; set; }
    }
}
