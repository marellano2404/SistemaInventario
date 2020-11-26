using Almacen.Core.BL.SalidasAlmacen.Interfaces;
using Almacen.Core.Models;
using Almacen.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Almacen.Core.BL.Almacen.Interfaces;

namespace Almacen.Core.BL.Almacen.Services 
{
    public class AlmacenServices : IAlmacen
    {
        public async Task<List<ArticulosInventarioVM>> GetListaInventario()
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var listaEntradas = new List<ArticulosInventarioVM>();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "[Almacen].[GetListaInventarioAlmacen]";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    //comando.Parameters.AddWithValue("@Folio", folio.Trim());

                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            ArticulosInventarioVM resultado = new ArticulosInventarioVM();
                            resultado.IdInventario = Lectura.GetGuid(0);
                            resultado.IdArticulo = Lectura.GetGuid(1);
                            resultado.ClaveProducto = Lectura.GetString(2);
                            resultado.ClaveInventario = Lectura.GetString(3);
                            resultado.CodigoBarras = Lectura.GetString(4);
                            resultado.Descripcion = Lectura.GetString(5);
                            resultado.Detalles = Lectura.GetString(6);
                            resultado.FechaCaducidad = Lectura.GetDateTime(7);
                            resultado.TipoCatalogo = Lectura.GetString(8);
                            resultado.Unidad = Lectura.GetString(9);
                            resultado.CantidadPorUnidad = Lectura.GetInt32(10);
                            resultado.Cantidad = Lectura.GetInt32(11);
                            resultado.ExistenciasUnidad = Lectura.GetInt32(12);
                            resultado.Laboratorio = Lectura.GetString(13);
                            resultado.Estado = Lectura.GetString(14);
                            listaEntradas.Add(resultado);
                        }
                    }
                    Conexion.Close();
                    return listaEntradas;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    throw e;
                }
            }
        }
    }
}
