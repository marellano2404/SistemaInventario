using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Farmacias", Schema = "Estructura")]
    public partial class Farmacias
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }
    }
}
