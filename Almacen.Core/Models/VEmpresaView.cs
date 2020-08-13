using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Keyless]
    public partial class VEmpresaView
    {
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
        [StringLength(50)]
        public string Municipio { get; set; }
        [StringLength(15)]
        public string NombreArchivo { get; set; }
        [StringLength(10)]
        public string TipoArchivo { get; set; }
        [StringLength(50)]
        public string RutaImagen { get; set; }
    }
}
