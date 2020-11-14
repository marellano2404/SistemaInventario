using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using Almacen.Portal.Models;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using static Almacen.Portal.Models.DatosReporteSalidaAlmacen;

namespace Almacen.Portal.Controllers
{
    public class AlmacenController : Controller
    {
        private IHostingEnvironment hostingEnv;
        public AlmacenController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _AgregarSalidaInventario()
        {
            return PartialView();
        }
        //[HttpPost]
        //public IActionResult RptSalidaAlmacen([FromForm] IFormCollection SalidadeAlmacen)
        //{
        //    DatosReporteSalidaAlmacen datosReporte = new DatosReporteSalidaAlmacen();

        //    var IdSt = SalidadeAlmacen["Id"].ToString();
        //    var FolioSt = SalidadeAlmacen["Folio"].ToString();
        //    var FechaCapturaSt = SalidadeAlmacen["FechaCaptura"].ToString();
        //    var FechaSalidaSt = SalidadeAlmacen["FechaSalida"].ToString();
        //    var FarmaciaSt = SalidadeAlmacen["Farmacia"].ToString();
        //    var AlmacenSt = SalidadeAlmacen["Almacen"].ToString();
        //    var ResponsableST = SalidadeAlmacen["Responsable"].ToString();

        //    datosReporte.Cabecera.Id = Guid.Parse(IdSt.ToString());
        //    datosReporte.Cabecera.Folio = FolioSt.Trim();
        //    datosReporte.Cabecera.FechaCaptura = DateTime.Parse(FechaCapturaSt.ToString());
        //    datosReporte.Cabecera.FechaSalida = DateTime.Parse(FechaSalidaSt.ToString());
        //    datosReporte.Cabecera.Farmacia = FarmaciaSt.Trim();
        //    datosReporte.Cabecera.Almacen = AlmacenSt.Trim();
        //    datosReporte.Cabecera.Responsable = ResponsableST.Trim();

        //    List<DetalleSalidaVM> listaDetalle = new List<DetalleSalidaVM>();
        //    DetalleSalidaVM DetalleSalida = new DetalleSalidaVM()
        //    {
        //        Cantidad = 1,
        //        Descripcion = "articulo1",
        //        ClaveProducto = "clave1",
        //        CodigoBarras = "138626829",
        //        Detalles = "detalle1",
        //        Estado = 1,
        //        ExistenciasUnidad = 10,
        //        FechaCaducidad = DateTime.Parse("2020-01-01".ToString()),
        //        TipoCatalogo = "CAUSES",
        //        Unidad = "CAJA"
        //    };
        //    listaDetalle.Add(DetalleSalida);
        //    DetalleSalidaVM DetalleSalida2 = new DetalleSalidaVM()
        //    {
        //        Cantidad = 1,
        //        Descripcion = "articulo2",
        //        ClaveProducto = "clave2",
        //        CodigoBarras = "7138626829",
        //        Detalles = "detalle2",
        //        Estado = 1,
        //        ExistenciasUnidad = 5,
        //        FechaCaducidad = DateTime.Parse("2020-01-01".ToString()),
        //        TipoCatalogo = "CAUSES",
        //        Unidad = "CAJA"
        //    };
        //    listaDetalle.Add(DetalleSalida2);

        //    foreach (var item in listaDetalle)
        //    {
        //        datosReporte.Lista.Add(item);
        //    }

        //    return new Rotativa.AspNetCore.ViewAsPdf("RptSalidaAlmacen", datosReporte)
        //    {
        //        PageSize = Rotativa.AspNetCore.Options.Size.Letter,
        //        PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
        //        FileName = "RptSalidadeAlmacen.pdf"
        //    };
        //}
        [HttpPost]
        public IActionResult RptSalidaAlmacen([FromForm] IFormCollection SalidadeAlmacen)
        {
            DatosReporteSalidaAlmacen datosReporte = new DatosReporteSalidaAlmacen();

            var IdSt = SalidadeAlmacen["Id"].ToString();
            var FolioSt = SalidadeAlmacen["Folio"].ToString();
            var FechaCapturaSt = SalidadeAlmacen["FechaCaptura"].ToString();
            var FechaSalidaSt = SalidadeAlmacen["FechaSalida"].ToString();
            var FarmaciaSt = SalidadeAlmacen["Farmacia"].ToString();
            var AlmacenSt = SalidadeAlmacen["Almacen"].ToString();
            var ResponsableST = SalidadeAlmacen["Responsable"].ToString();

            datosReporte.Cabecera.Id = Guid.Parse(IdSt.ToString());
            datosReporte.Cabecera.Folio = FolioSt.Trim();
            datosReporte.Cabecera.FechaCaptura = DateTime.Parse(FechaCapturaSt.ToString());
            datosReporte.Cabecera.FechaSalida = DateTime.Parse(FechaSalidaSt.ToString());
            datosReporte.Cabecera.Farmacia = FarmaciaSt.Trim();
            datosReporte.Cabecera.Almacen = AlmacenSt.Trim();
            datosReporte.Cabecera.Responsable = ResponsableST.Trim();

            List<DetalleSalidaVM> listaDetalle = new List<DetalleSalidaVM>();
            DetalleSalidaVM DetalleSalida = new DetalleSalidaVM()
            {
                Cantidad = 1,
                Descripcion = "articulo1",
                ClaveProducto = "clave1",
                CodigoBarras = "138626829",
                Detalles = "detalle1",
                Estado = 1,
                ExistenciasUnidad = 10,
                FechaCaducidad = DateTime.Parse("2020-01-01".ToString()),
                TipoCatalogo = "CAUSES",
                Unidad = "CAJA"
            };
            listaDetalle.Add(DetalleSalida);
            DetalleSalidaVM DetalleSalida2 = new DetalleSalidaVM()
            {
                Cantidad = 1,
                Descripcion = "articulo2",
                ClaveProducto = "clave2",
                CodigoBarras = "7138626829",
                Detalles = "detalle2",
                Estado = 1,
                ExistenciasUnidad = 5,
                FechaCaducidad = DateTime.Parse("2020-01-01".ToString()),
                TipoCatalogo = "CAUSES",
                Unidad = "CAJA"
            };
            listaDetalle.Add(DetalleSalida2);

            foreach (var item in listaDetalle)
            {
                datosReporte.Lista.Add(item);
            }

            return PartialView(datosReporte);
        }
            private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }
    }
}
