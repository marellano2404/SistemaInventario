using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("DetalleSalidaFarmacia", Schema = "Almacen")]
    public partial class DetalleSalidaFarmacia
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdSalidaFarmacia { get; set; }
    }
}
