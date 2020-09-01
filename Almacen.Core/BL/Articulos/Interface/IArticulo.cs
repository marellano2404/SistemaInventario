using Almacen.Core.ViewModels.Auxiliars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Articulos.Interface
{
    public interface IArticulo
    {
        Task<List<ViewModels.Articulo>> ObtenerArticulos(ViewModels.Auxiliars.Pagination P);
        Task<ViewModels.Articulo> ObtenerArticulo(string Id);
        Task<MensajeRespuesta> InsertarArticulos(ViewModels.Articulo A);
        Task<MensajeRespuesta> ModificarArticulo(ViewModels.Articulo A);
        Task<MensajeRespuesta> EliminarArticulo(string IdArticulo);
    }
}
