using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Almacen", Schema = "Estructura")]
    public partial class Almacen
    {
        public Almacen()
        {
            InverseIdPadreNavigation = new HashSet<Almacen>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? IdPadre { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        public Guid? IdMunicipio { get; set; }
        public Guid? IdGerente { get; set; }
        public int? TipoEstablecimiento { get; set; }

        [ForeignKey(nameof(IdGerente))]
        [InverseProperty(nameof(Usuarios.Almacen))]
        public virtual Usuarios IdGerenteNavigation { get; set; }
        [ForeignKey(nameof(IdMunicipio))]
        [InverseProperty(nameof(Municipios.Almacen))]
        public virtual Municipios IdMunicipioNavigation { get; set; }
        [ForeignKey(nameof(IdPadre))]
        [InverseProperty(nameof(Almacen.InverseIdPadreNavigation))]
        public virtual Almacen IdPadreNavigation { get; set; }
        [ForeignKey(nameof(TipoEstablecimiento))]
        [InverseProperty(nameof(TipoFarmacia.Almacen))]
        public virtual TipoFarmacia TipoEstablecimientoNavigation { get; set; }
        [InverseProperty(nameof(Almacen.IdPadreNavigation))]
        public virtual ICollection<Almacen> InverseIdPadreNavigation { get; set; }
    }
}
