using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Empresa", Schema = "Estructura")]
    public partial class Empresa
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string NombreEmpresa { get; set; }
        [Column("RFC")]
        [StringLength(13)]
        public string Rfc { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        [StringLength(150)]
        public string Direccion { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }
        [StringLength(150)]
        public string Propietario { get; set; }
        [StringLength(200)]
        public string Slogan { get; set; }
        public Guid? IdMunicipio { get; set; }
        public Guid? IdLogo { get; set; }

        [ForeignKey(nameof(IdLogo))]
        [InverseProperty(nameof(Archivos.Empresa))]
        public virtual Archivos IdLogoNavigation { get; set; }
        [ForeignKey(nameof(IdMunicipio))]
        [InverseProperty(nameof(Municipios.Empresa))]
        public virtual Municipios IdMunicipioNavigation { get; set; }
    }
}
