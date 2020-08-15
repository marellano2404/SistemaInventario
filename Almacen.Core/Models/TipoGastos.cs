using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("TipoGastos", Schema = "Catalogos")]
    public partial class TipoGastos
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
