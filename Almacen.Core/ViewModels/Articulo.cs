using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Almacen.Core.ViewModels
{
    public class Articulo
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Descripcion { get; set; }
        
        public string ClaveProducto { get; set; }
        
        public string Detalles { get; set; }

        public string Presentacion { get; set; }

        public string Marca { get; set; }
        
        public string Modelo { get; set; }
        
        public int? TipoMedicamento { get; set; }
        
        public string TipoCatalogo { get; set; }

        public int? UnidadMedida { get; set; }

        public int? CantidadPorUnidad { get; set; }

        public string CodigoBarras { get; set; }

        public int? Laboratorio { get; set; }
        
        public int? Estado { get; set; }

        public int Cantidad { get; set; }
    }
}
