using Almacen.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.SalidasAlmacen.Interfaces
{
    public interface ISalidasAlmacen
    {
        Task<SalidasAlmacenViewModel> GetSalidasAlmacen(string estado);
    }
}
