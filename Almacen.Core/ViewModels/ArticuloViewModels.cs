using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core.ViewModels
{
    public class ArticulosViewModel
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string ClaveProducto { get; set; }
        public string Detalles { get; set; }
        public string Presentacion { get; set; }
        public string Marca { get; set; }
        public string Lote { get; set; }
        public int? TipoMedicamento { get; set; }
        public string TipoCatalogo { get; set; }
        public int? UnidadMedida { get; set; }
        public int? CantidadPorUnidad { get; set; }
        public string CodigoBarras { get; set; }
        public int? Laboratorio { get; set; }
        public int? Estado { get; set; }
        public int? Cantidad { get; set; }

    }

    public class ArticuloViewModel
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string ClaveProducto { get; set; }
        public string Detalles { get; set; }
        public string Presentacion { get; set; }
        public string Marca { get; set; }
        public string Lote { get; set; }
        public string TipoMedicamento { get; set; } //int
        public string TipoCatalogo { get; set; }
        public string UnidadMedida { get; set; } //int
        public int? CantidadPorUnidad { get; set; }
        public string CodigoBarras { get; set; }
        public int? Laboratorio { get; set; }
    }
}
