using Almacen.Core.BL.SalidasAlmacen.Interfaces;
using Almacen.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.SalidasAlmacen.Services
{
    public class SalidasAlmacenService : ISalidasAlmacen
    {
        public async Task<SalidasAlmacenViewModel> GetSalidasAlmacen(string estado)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var resultado = new SalidasAlmacenViewModel() { Exito = false, Mensaje = "Existe un error en Servidor" };
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "Almacen.[GetSalidasAlmacen]";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Estado", estado);
                    comando.Parameters.AddWithValue("@IdSalida", null);

                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            resultado.Exito = Lectura.GetBoolean(0);
                            resultado.Mensaje = Lectura.GetString(1);
                            resultado.Id = Lectura.GetGuid(2);
                            resultado.Folio = Lectura.GetString(3);
                            resultado.FechaCaptura = Lectura.GetDateTime(4);
                            resultado.FechaSalida = Lectura.GetDateTime(5);
                            resultado.Farmacia = Lectura.GetString(6);
                            resultado.Almacen = Lectura.GetString(7);
                            resultado.Responsable = Lectura.GetString(8);
                        }
                    }
                    Conexion.Close();
                    return resultado;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    return resultado;
                }
            }
        }
    }
}
