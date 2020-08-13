using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Seguridad.Interfaces
{
    public interface ISeguridad
    {
        Task<bool> VerificaConexion();
    }
}
