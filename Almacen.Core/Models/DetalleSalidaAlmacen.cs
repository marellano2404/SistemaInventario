using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("DetalleSalidaAlmacen", Schema = "Almacen")]
    public partial class DetalleSalidaAlmacen
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdSalida { get; set; }
    }
}
