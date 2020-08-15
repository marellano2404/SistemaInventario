using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("SalidasAlmacen", Schema = "Almacen")]
    public partial class SalidasAlmacen
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Folio { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaVenta { get; set; }
        public Guid? IdCliente { get; set; }
        public Guid? IdEstablecimiento { get; set; }
    }
}
