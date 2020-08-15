using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("TipoServicios", Schema = "Catalogos")]
    public partial class TipoServicios
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
    }
}
