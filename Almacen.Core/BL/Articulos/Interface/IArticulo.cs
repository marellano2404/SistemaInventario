using Almacen.Core.ViewModels.Auxiliars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Articulos.Interface
{
    public interface IArticulo
    {
        Task<List<ViewModels.ArticulosViewModel>> ObtenerArticulos(ViewModels.Auxiliars.Pagination P);
        Task<ViewModels.ArticulosViewModel> ObtenerArticulo(string Id);
        Task<MensajeRespuesta> InsertarArticulos(ViewModels.ArticuloViewModel A);
        Task<MensajeRespuesta> ModificarArticulo(ViewModels.ArticuloViewModel A);
        Task<MensajeRespuesta> EliminarArticulo(string IdArticulo);
    }
}
