using Almacen.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Catalogos.Interface
{
    public interface ITipoUnidad
    {
        Task<List<TipoUnidadesViewModel>> ObtenerTipoUnidades();
    }
}
