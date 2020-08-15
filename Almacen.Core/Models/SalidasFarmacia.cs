using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("SalidasFarmacia", Schema = "Almacen")]
    public partial class SalidasFarmacia
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fechasalida { get; set; }
    }
}
