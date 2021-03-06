﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Portal.Models
{
    public class DatosReporteSalidaAlmacen
    {
        public class SalidaAlmacen
        {
            public Guid Id { get; set; }
            public string Folio { get; set; }
            public DateTime FechaCaptura { get; set; }
            public DateTime FechaSalida { get; set; }
            public string Farmacia { get; set; }
            public string Almacen { get; set; }
            public string Responsable { get; set; }
            public string Mensaje { get; set; }
            public bool Exito { get; set; }
        }
          
        public class DetalleSalidaVM
        {
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
        public SalidaAlmacen Cabecera { get; set; }
        public List<DetalleSalidaVM> Lista { get; set; }
        public DatosReporteSalidaAlmacen()
        {
            this.Cabecera = new SalidaAlmacen();
            this.Lista = new List<DetalleSalidaVM>();
        }
    }
}
