using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Portal.Controllers
{
    public class AlmacenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _AgregarSalidaInventario()
        {
            return PartialView();
        }
    }
}
