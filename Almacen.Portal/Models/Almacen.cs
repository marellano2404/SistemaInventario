using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Portal.Models
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
}
