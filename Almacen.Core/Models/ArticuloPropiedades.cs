using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("ArticuloPropiedades", Schema = "Catalogos")]
    public partial class ArticuloPropiedades
    {
        [Key]
        public Guid Id { get; set; }
        public int? IdTipoArticulo { get; set; }
        public bool? Propiedad01 { get; set; }
        public bool? Propiedad02 { get; set; }
        public bool? Propiedad03 { get; set; }
        public bool? Propiedad04 { get; set; }
        public bool? Propiedad05 { get; set; }
        public bool? Propiedad06 { get; set; }
        public bool? Propiedad07 { get; set; }
        public bool? Propiedad08 { get; set; }
        public bool? Propiedad09 { get; set; }
        public bool? Propiedad10 { get; set; }
    }
}
