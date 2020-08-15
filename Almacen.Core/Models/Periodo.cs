using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Periodo", Schema = "Catalogos")]
    public partial class Periodo
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        public int? Ejercicio { get; set; }
        public int? IdTemporada { get; set; }
    }
}
