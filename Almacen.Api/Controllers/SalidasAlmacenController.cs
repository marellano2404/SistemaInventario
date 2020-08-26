using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core.BL.SalidasAlmacen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidasAlmacenController : ControllerBase
    {
        #region PROPIEDADES

        private readonly ISalidasAlmacen _SalidasAlmacenService;


        #endregion

        #region CONTRUCTOR
        public SalidasAlmacenController(ISalidasAlmacen SalidasAlmacendService)
        {
            _SalidasAlmacenService = SalidasAlmacendService;
        }
        #endregion

        #region METODOS
        /*
        */
        [HttpGet("GetSalidasAlmacen")]
        public async Task<IActionResult> GetSalidasAlmacen(string Estado)
        {
            try
            {
                //var token = new JWTViewModel();
                var resultado = await _SalidasAlmacenService.GetSalidasAlmacen(Estado);
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
