using Almacen.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Seguridad.Interfaces
{
    public interface ISeguridad
    {
        Task<bool> VerificaConexion();
        Task<ResultadoLoginViewModel> AutentificacionUsuario(LoginViewModel usuario);
        Task<JWTViewModel> GenerarToken(ResultadoLoginViewModel resultado);
        Task<bool> RegistrarHistorial(string opcion, string idUser, string detalles);
        
    }
}
