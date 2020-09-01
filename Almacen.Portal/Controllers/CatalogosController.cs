using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Almacen.Portal.Controllers
{
    public class CatalogosController : Controller
    {
      
        public IActionResult Index()
        {
            //return new ViewAsPdf("Index")
            //{
            //    PageSize = Rotativa.AspNetCore.Options.Size.Letter,
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
            //    //FileName = "ReporteUsuarios.pdf"
            //};
            return View();
        }
        public IActionResult Articulos()
        {
            return View();
        }
    }
}
