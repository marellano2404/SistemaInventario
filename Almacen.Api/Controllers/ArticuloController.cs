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
        public async Task<IActionResult> ObtenerArticulos([FromBody] Pagination datos)
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

        [HttpPost("InsertarArticulo")]
        public async Task<IActionResult> InsertarArticulo([FromBody] ArticuloViewModel datoArticulo)
        {
            try
            {
                var response = await _articulo.InsertarArticulos(datoArticulo);
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("ModificarArticulo")]
        public async Task<IActionResult> ModificarArticulo([FromBody] ArticuloViewModel datos)
        {
            try
            {
                var response = await _articulo.ModificarArticulo(datos);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("EliminarArticulo/{id}")]
        public async Task<IActionResult> EliminarArticulo(string id)
        {
            try
            {
                var response = await _articulo.EliminarArticulo(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
