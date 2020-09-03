using Almacen.Core.BL.Catalogos.Interface;
using Almacen.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Catalogos.Services
{
    public class TipoUnidadesService : ITipoUnidad
    {
        public async Task<List<TipoUnidadesViewModel>> ObtenerTipoUnidades()
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                List<TipoUnidadesViewModel> Lista = new List<TipoUnidadesViewModel>();
                try
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "Catalogos.ObtenerTipoUnidades";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerTipoUnidades");
                    conexion.Open();

                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows) //que tenga renglones
                    {
                        while (lectura.Read())
                        {
                            Lista.Add(
                                new TipoUnidadesViewModel
                                {
                                    Id = lectura.GetInt32(0),
                                    Descripcion = lectura.GetString(1)
                                });
                        }
                    }
                    conexion.Close();
                    return Lista;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    return Lista;
                }
            }
        }
    }
}
