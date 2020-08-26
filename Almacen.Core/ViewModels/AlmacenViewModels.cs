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
}
