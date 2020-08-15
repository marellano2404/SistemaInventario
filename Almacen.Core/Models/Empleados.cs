using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Empleados", Schema = "Estructura")]
    public partial class Empleados
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Nombres { get; set; }
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [Column("RFC")]
        [StringLength(13)]
        public string Rfc { get; set; }
        [StringLength(7)]
        public string CodigoPuesto { get; set; }
        [StringLength(5)]
        public string Turno { get; set; }
        [StringLength(50)]
        public string Servicio { get; set; }
    }
}
