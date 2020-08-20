using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Articulos.Interface
{
    public interface IArticulo
    {
        public Task<List<ViewModels.Articulo>> ObtenerArticulos(ViewModels.Auxiliars.Pagination P);
        public Task<ViewModels.Articulo> ObtenerArticulo(string Id);
    }
}
