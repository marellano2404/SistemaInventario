using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core.BL.Catalogos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUnidadesController : ControllerBase
    {
        private readonly ITipoUnidad _tipoUnidad;

        public TipoUnidadesController(ITipoUnidad tipoUnidad)
        {
            _tipoUnidad = tipoUnidad;
        }

        [HttpGet("ObtenerTipoUnidades")]
        public async Task<IActionResult> ObtenerTipoUnidades()
        {
            try
            {
                var response = await _tipoUnidad.ObtenerTipoUnidades();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
