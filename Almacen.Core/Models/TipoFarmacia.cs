using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("TipoFarmacia", Schema = "Catalogos")]
    public partial class TipoFarmacia
    {
        public TipoFarmacia()
        {
            Almacen = new HashSet<Almacen>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("TipoEstablecimientoNavigation")]
        public virtual ICollection<Almacen> Almacen { get; set; }
    }
}
