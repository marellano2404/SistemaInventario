using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("Articulos", Schema = "Catalogos")]
    public partial class Articulos
    {
        public Articulos()
        {
            InventarioAlmacen = new HashSet<InventarioAlmacen>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(2000)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string ClaveProducto { get; set; }
        [StringLength(2000)]
        public string Detalles { get; set; }
        [StringLength(50)]
        public string Marca { get; set; }
        [StringLength(50)]
        public string Modelo { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [Column(TypeName = "numeric(2, 1)")]
        public decimal? Numero { get; set; }
        [StringLength(500)]
        public string Presentacion { get; set; }
        public int? TipoMaterial { get; set; }
        [StringLength(50)]
        public string TipoMedicamento { get; set; }
        public int? UnidadMedida { get; set; }
        public int? Estado { get; set; }

        [InverseProperty("IdArticuloNavigation")]
        public virtual ICollection<InventarioAlmacen> InventarioAlmacen { get; set; }
    }
}
