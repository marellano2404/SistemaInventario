using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Municipios", Schema = "Catalogos")]
    public partial class Municipios
    {
        public Municipios()
        {
            Almacen = new HashSet<Almacen>();
            Empresa = new HashSet<Empresa>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Municipio { get; set; }
        public Guid? IdEstado { get; set; }

        [ForeignKey(nameof(IdEstado))]
        [InverseProperty(nameof(Estados.Municipios))]
        public virtual Estados IdEstadoNavigation { get; set; }
        [InverseProperty("IdMunicipioNavigation")]
        public virtual ICollection<Almacen> Almacen { get; set; }
        [InverseProperty("IdMunicipioNavigation")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
