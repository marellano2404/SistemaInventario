using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Archivos", Schema = "Estructura")]
    public partial class Archivos
    {
        public Archivos()
        {
            Empresa = new HashSet<Empresa>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(15)]
        public string NombreArchivo { get; set; }
        [StringLength(10)]
        public string TipoArchivo { get; set; }
        [StringLength(50)]
        public string RutaImagen { get; set; }

        [InverseProperty("IdLogoNavigation")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
