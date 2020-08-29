using Almacen.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.SalidasAlmacen.Interfaces
{
    public interface ISalidasAlmacen
    {
        Task<List<SalidasAlmacenViewModel>> GetSalidasAlmacen(int estado);
        Task<List<DetalleSalidaViewModel>> GetDetalleSalidaAlmacen(string folio);
        Task<ResultViewModel>DelDetalleSalidaAlmacen(Guid idDetalleSalidaAlmacen);
        Task<ArticulosInventarioVM> BuscarArticuloInventario(string tipo, string valor);
        Task<ResultViewModel>PutDetalleSalidaAlmacen(ArticuloSalidaAlmacenVM articuloSalidaAlmacen);
    }
}
