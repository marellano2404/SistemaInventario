using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("ResguardoFarmacia", Schema = "Almacen")]
    public partial class ResguardoFarmacia
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdFarmacia { get; set; }
    }
}
