using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Clientes", Schema = "Catalogos")]
    public partial class Clientes
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellidos { get; set; }
        [StringLength(150)]
        public string Direccion { get; set; }
        [Column(TypeName = "numeric(11, 0)")]
        public decimal? Telefono { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        public int? Estado { get; set; }
    }
}
