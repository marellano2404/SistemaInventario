using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core.BL.Articulos.Interface;
using Almacen.Core.ViewModels;
using Almacen.Core.ViewModels.Auxiliars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticulo _articulo;

        public ArticuloController(IArticulo articulo)
        {
            _articulo = articulo;
        }

        [HttpPost("ObtenerArticulos")]
        public async Task<IActionResult> ObtenerTipoInmuebles([FromBody] Pagination datos)
        {
            try
            {
                var response = await _articulo.ObtenerArticulos(datos);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("ObtenerArticulo/{id}")]
        public async Task<IActionResult> ObtenerArticulo(string id)
        {
            try
            {
                var response = await _articulo.ObtenerArticulo(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Articulo datos)
        {
            try
            {
                var response = await _articulo.InsertarArticulos(datos);
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
