using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Almacen.Portal.Controllers
{
    public class CrearPDFController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            //var datos = await ObtenerUsuarios();
            return new ViewAsPdf("Index")
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
                //FileName = "ReporteUsuarios.pdf"
            };
        }
    }
}
