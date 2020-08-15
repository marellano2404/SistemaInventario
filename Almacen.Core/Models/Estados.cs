using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Estados", Schema = "Catalogos")]
    public partial class Estados
    {
        public Estados()
        {
            Municipios = new HashSet<Municipios>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Estado { get; set; }
        [StringLength(10)]
        public string Clave { get; set; }
        [StringLength(10)]
        public string Numero { get; set; }

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Municipios> Municipios { get; set; }
    }
}
