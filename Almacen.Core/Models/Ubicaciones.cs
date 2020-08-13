using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Ubicaciones", Schema = "Catalogos")]
    public partial class Ubicaciones
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Primario { get; set; }
        [StringLength(50)]
        public string Secundario { get; set; }
    }
}
