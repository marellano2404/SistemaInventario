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
    public class LaboratorioController : ControllerBase
    {
        private readonly ILaboratorio _laboratorio;

        public LaboratorioController(ILaboratorio laboratorio)
        {
            _laboratorio = laboratorio;
        }

        [HttpGet("ObtenerLaboratorios")]
        public async Task<IActionResult> ObtenerLaboratorios()
        {
            try
            {
                var response = await _laboratorio.ObtenerLaboratorios();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
