using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("TipoUnidades", Schema = "Almacen")]
    public partial class TipoUnidades
    {
        public TipoUnidades()
        {
            InventarioAlmacen = new HashSet<InventarioAlmacen>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty("TipoUnidadNavigation")]
        public virtual ICollection<InventarioAlmacen> InventarioAlmacen { get; set; }
    }
}
