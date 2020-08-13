using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Usuarios", Schema = "Seguridad")]
    public partial class Usuarios
    {
        public Usuarios()
        {
            Almacen = new HashSet<Almacen>();
            InventarioAlmacen = new HashSet<InventarioAlmacen>();
            Permisos = new HashSet<Permisos>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? IdEmpleado { get; set; }
        [StringLength(250)]
        public string NombreCompleto { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(60)]
        public string Password { get; set; }
        public bool? Habilitado { get; set; }

        [InverseProperty("IdGerenteNavigation")]
        public virtual ICollection<Almacen> Almacen { get; set; }
        [InverseProperty("IdResponsableNavigation")]
        public virtual ICollection<InventarioAlmacen> InventarioAlmacen { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
