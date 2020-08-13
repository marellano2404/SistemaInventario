using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Funcionalidades", Schema = "Seguridad")]
    public partial class Funcionalidades
    {
        public Funcionalidades()
        {
            RolesFuncionalidades = new HashSet<RolesFuncionalidades>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool? Status { get; set; }

        [InverseProperty("IdFuncionalidadNavigation")]
        public virtual ICollection<RolesFuncionalidades> RolesFuncionalidades { get; set; }
    }
}
