using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core.BL.Seguridad.Interfaces;
using Almacen.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
          #region PROPIEDADES

        private readonly ISeguridad _SeguridadService;


        #endregion

        #region CONTRUCTOR
        public SeguridadController(ISeguridad SeguridadService)
        {
            _SeguridadService = SeguridadService;
        }
        #endregion

        #region METODOS
       

        [HttpPost("AutenticarUsuario")]
        public async Task<IActionResult> AutentificacionUsuario([FromBody] LoginViewModel Usuarioview)
        {
            try
            {
                var Resultado = await _SeguridadService.AutentificacionUsuario(Usuarioview);
                if (Resultado != null)
                {
                    var TokenGenerado = await _SeguridadService.GenerarToken(Resultado);
                    if (TokenGenerado != null)
                    {
                        return Ok(TokenGenerado);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

                var valor = ex.Message.ToString();
                return Ok();
            }
        }
        [HttpGet("RegistrarHistorialAlumno")]
        public async Task<IActionResult> PuthistorialAlumno(string Opcion, string IdUser, string Detalles)
        {
            try
            {
                //var token = new JWTViewModel();
                var resultado = await _SeguridadService.RegistrarHistorial(Opcion, IdUser, Detalles);
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
