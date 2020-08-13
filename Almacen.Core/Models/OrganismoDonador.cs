using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("OrganismoDonador", Schema = "Catalogos")]
    public partial class OrganismoDonador
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string NombreProveedor { get; set; }
    }
}
