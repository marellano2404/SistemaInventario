using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("InventarioAlmacen", Schema = "Almacen")]
    public partial class InventarioAlmacen
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string ClaveInventario { get; set; }
        public Guid? IdArticulo { get; set; }
        public int? Cantidad { get; set; }
        public Guid? IdProveedor { get; set; }
        public int? IdUbicacion { get; set; }
        public int? TipoUnidad { get; set; }
        public Guid? IdResponsable { get; set; }
        public int? Estado { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaAlta { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaCaducidad { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal PrecioCompra { get; set; }

        [ForeignKey(nameof(IdArticulo))]
        [InverseProperty(nameof(Articulos.InventarioAlmacen))]
        public virtual Articulos IdArticuloNavigation { get; set; }
        [ForeignKey(nameof(IdResponsable))]
        [InverseProperty(nameof(Usuarios.InventarioAlmacen))]
        public virtual Usuarios IdResponsableNavigation { get; set; }
        [ForeignKey(nameof(TipoUnidad))]
        [InverseProperty(nameof(TipoUnidades.InventarioAlmacen))]
        public virtual TipoUnidades TipoUnidadNavigation { get; set; }
    }
}
