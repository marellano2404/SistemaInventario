using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core.ViewModels
{
    public class SalidasAlmacenViewModel
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public Guid Id { get; set; }
        public string Folio { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Farmacia { get; set; }
        public string Almacen { get; set; }
        public string Responsable { get; set; }
    }
    public class DetalleSalidaViewModel
    {
        public Guid IdSalidaAlmacen { get; set; }
        public string ClaveProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Detalles { get; set; }
        public string Unidad { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string TipoCatalogo { get; set; }
        public int ExistenciasUnidad { get; set; }
        public int Estado { get; set; }
    }
}
