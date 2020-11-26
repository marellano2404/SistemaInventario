using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core.BL.Almacen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        #region PROPIEDADES

        private readonly IAlmacen _AlmacenService;


        #endregion

        #region CONTRUCTOR
        public AlmacenController(IAlmacen AlmacendService)
        {
            _AlmacenService = AlmacendService;
        }
        #endregion
        #region METODOS
        /*
        */
        [HttpPost("GetInventarioAlmacen")]
        public async Task<IActionResult> GetSalidasAlmacen()
        {
            try
            {
                var resultado = await _AlmacenService.GetListaInventario();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message.ToString();
                return BadRequest();
            }
        }
        #endregion

    }
}
