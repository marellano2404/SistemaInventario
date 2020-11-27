using Almacen.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Almacen.Interfaces
{
    public interface IAlmacen
    {
        Task<List<ArticulosInventarioVM>> GetListaInventario();
        Task<List<EntradasAlmacenVM>> GetEntradasdeAlmacen(int estado);
    }
}
