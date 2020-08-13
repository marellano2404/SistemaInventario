using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Keyless]
    [Table("Transferencias", Schema = "Almacen")]
    public partial class Transferencias
    {
        public Guid? Id { get; set; }
    }
}
